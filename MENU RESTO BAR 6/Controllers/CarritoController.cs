using MENU_RESTO_BAR_6.Models;
using MENU_RESTO_BAR_6.Views.Productos;
using Microsoft.AspNetCore.Mvc;

namespace MENU_RESTO_BAR_6.Controllers
{
    public class CarritoController: Controller
    {

        private const string CartSessionKey = "Cart";

        public IActionResult Index()
        {
            var cart = GetCartFromSession();
            return View(cart); // Muestra los productos en el carrito
        }

        [HttpPost]
        public IActionResult AddToCart(int id, string nombre, decimal precio, string descripcion, Categoria categoria)
        {
            var cart = GetCartFromSession();

            
            cart.Add(new Producto { ProductoId = id, Nombre = nombre, Precio = precio, Descripcion = descripcion,Categoria = categoria});
            

            SaveCartToSession(cart);

            return Json(new { success = true });
        }

        private List<Producto> GetCartFromSession()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<Producto>>(CartSessionKey);
            return cart ?? new List<Producto>();
        }

        private void SaveCartToSession(List<Producto> cart)
        {
            HttpContext.Session.SetObjectAsJson(CartSessionKey, cart);
        }

    }
}
