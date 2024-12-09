using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MENU_RESTO_BAR_6.Context;
using MENU_RESTO_BAR_6.Models;

namespace MENU_RESTO_BAR_6.Controllers
{
    public class CarritoController : Controller
    {
        private readonly CafeDel6DbContext _context;

        public CarritoController(CafeDel6DbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
           
            var carrito = _context.Carritos
                .Include(c => c.Items)
                .ThenInclude(ci => ci.Producto) 
                .FirstOrDefault(c => !c.Comprado);

            if (carrito == null)
            {
                
                carrito = new Carrito { Comprado = false, FechaCreacion = DateTime.Now };
                _context.Carritos.Add(carrito);
                _context.SaveChanges();
            }

            
            return View(carrito);
        }

        public IActionResult Agregar(int productoId)
        {
         
            var carrito = _context.Carritos.FirstOrDefault(c => !c.Comprado);

            if (carrito == null)
            {
               
                carrito = new Carrito { Comprado = false, FechaCreacion = DateTime.Now };
                _context.Carritos.Add(carrito);
                _context.SaveChanges();
            }

            
            var producto = _context.Productos.FirstOrDefault(p => p.ProductoId == productoId);

            if (producto == null)
            {
                return NotFound("Producto no encontrado.");
            }

            
            var item = _context.CarritoItems
                .FirstOrDefault(ci => ci.CarritoId == carrito.CarritoId && ci.ProductoId == productoId);

            if (item == null)
            {
                item = new CarritoItem
                {
                    CarritoId = carrito.CarritoId,
                    ProductoId = productoId,
                    Cantidad = 1
                };
                _context.CarritoItems.Add(item);
            }
            else
            {
                item.Cantidad++;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Productos");
        }

        public IActionResult FinalizarCompra(int carritoId)
        {
            
            var carrito = _context.Carritos.Find(carritoId);

            if (carrito == null || carrito.Comprado)
            {
                return NotFound("Carrito no encontrado o ya procesado.");
            }

           
            carrito.Comprado = true;
            _context.SaveChanges();

           
            var nuevoCarrito = new Carrito { Comprado = false, FechaCreacion = DateTime.Now };
            _context.Carritos.Add(nuevoCarrito);
            _context.SaveChanges();

           
            TempData["SuccessMessage"] = "Compra realizada con exito. Tu carrito se vaciara.";
            return RedirectToAction("Index", "Carrito", new { carritoId = nuevoCarrito.CarritoId });
        }


    }
}
