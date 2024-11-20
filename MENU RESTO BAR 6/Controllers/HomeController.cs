using MENU_RESTO_BAR_6.Context;
using MENU_RESTO_BAR_6.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MENU_RESTO_BAR_6.Controllers
{
    public class HomeController : Controller
    {
        private readonly CafeDel6DbContext _context;

        public HomeController(CafeDel6DbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Index()
        {
            //var menuItems = _context.Producto
            //.OrderBy(m => m.Nombre)
            // .ToList();

            return View();
        }
        public IActionResult Reserva() {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}

