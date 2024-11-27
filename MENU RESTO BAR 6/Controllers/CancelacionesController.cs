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
    public class CancelacionesController : Controller
    {
        private readonly CafeDel6DbContext _context;

        public CancelacionesController(CafeDel6DbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cancelacion.ToListAsync());
        }

        // GET: Cancelaciones
        [HttpGet]
        public IActionResult CancelarReserva(int id)
        {
            var reserva = _context.Reservas.FirstOrDefault(r => r.ReservaId == id);

            if (reserva == null)
            {
                TempData["ErrorMessage"] = "La reserva no existe.";
                return RedirectToAction("Index");
            }

            // Pasamos el ID de la reserva al formulario de cancelación
            return View(new Cancelacion { ReservaId = id });
        }

        [HttpPost]
        public IActionResult CancelarReserva(Cancelacion cancelacion)
        {
            if (ModelState.IsValid)
            {
                cancelacion.FechaCancelacion = DateTime.Now;
                _context.Cancelacion.Add(cancelacion);

                var reserva = _context.Reservas.FirstOrDefault(r => r.ReservaId == cancelacion.ReservaId);
                if (reserva != null)
                {
                    reserva.Estado = EstadoReserva.Cancelada; // Cambiar el estado de la reserva
                }

                _context.SaveChanges();
                TempData["SuccessMessage"] = "Reserva cancelada exitosamente.";
                return RedirectToAction("Index");
            }

            return View(cancelacion);
        }
    }
}
