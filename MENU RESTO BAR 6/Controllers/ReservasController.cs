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
    public class ReservasController : Controller
    {
        private readonly CafeDel6DbContext _context;

        public ReservasController(CafeDel6DbContext context)
        {
            _context = context;
        }

        // GET: Reservas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reservas.ToListAsync());
        }

        // GET: Reservas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .FirstOrDefaultAsync(m => m.ReservaId == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        [HttpPost]
        public IActionResult CrearReserva(string usuarioEmail, int cantPersonas, DateTime fechaReserva)
        {
            // Buscar usuario por email
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == usuarioEmail);
            if (usuario == null)
            {
                TempData["ErrorMessage"] = "Usuario no encontrado.";
                return RedirectToAction("Create", "Reservas");
            }
            else if (fechaReserva < DateTime.Now.AddHours(48)) {
                TempData["ErrorMessage"] = "La fecha de reservacion tiene que ser mayor a la fecha actual y tener como minimo 48 horas de antelacion.";
                return RedirectToAction("Create", "Reservas");
            }

            // Crear nueva reserva asociada al usuario
            var nuevaReserva = new Reserva
            {
                UsuarioEmail = usuarioEmail,
                Usuario = usuario,
                CantPersonas = cantPersonas,
                FechaReserva = fechaReserva,
                Confirmada = false // Inicia como no confirmada
            };

            // Guardar la reserva en la base de datos
            _context.Reservas.Add(nuevaReserva);
            _context.SaveChanges();
            TempData["SuccessMessage"] = "Reserva creada con exito.";
            return RedirectToAction("Index", "Reservas");
        }

        // GET: Reservas/Create
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Buscar()
        {
            return View();
        }

        // POST: Reservas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReservaId,UsuarioEmail,CantPersonas,FechaReserva,Confirmada")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reserva);
        }

        // GET: Reservas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }
            return View(reserva);
        }

        // POST: Reservas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReservaId,UsuarioEmail,CantPersonas,FechaReserva,Confirmada")] Reserva reserva)
        {
            if (id != reserva.ReservaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaExists(reserva.ReservaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(reserva);
        }

        // GET: Reservas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .FirstOrDefaultAsync(m => m.ReservaId == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva != null)
            {
                _context.Reservas.Remove(reserva);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaExists(int id)
        {
            return _context.Reservas.Any(e => e.ReservaId == id);
        }

        [HttpGet]
        public IActionResult ReservasPorUsuario(string email)
        {
            // Validar el correo proporcionado
            if (string.IsNullOrEmpty(email))
            {
                TempData["ErrorMessage"] = "El correo electrónico es obligatorio.";
                return RedirectToAction("Index");
            }

            // Buscar las reservas asociadas al correo
            var reservas = _context.Reservas
                .Where(r => r.UsuarioEmail == email)
                .ToList();

            if (reservas == null || !reservas.Any())
            {
                TempData["ErrorMessage"] = "No se encontraron reservas para el correo proporcionado.";
                return RedirectToAction("Index");
            }

            // Retornar la vista con las reservas
            return View(reservas);
        }
    }
}
