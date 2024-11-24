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
        public IActionResult CrearReserva(string usuarioEmail, int cantPersonas, DateTime FechaReserva)
        {
            DateTime fechaActual = DateTime.Now;
            if (FechaReserva < fechaActual.AddHours(48))
            {
                Console.WriteLine($"Fecha actual: {fechaActual}");
                Console.WriteLine($"Fecha reservada: {FechaReserva}");
                return BadRequest("La reserva debe realizarse con al menos 48 horas de antelación.");
            }
           

            // Buscar usuario por email
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == usuarioEmail);
            if (usuario == null)
            {
                return NotFound("Usuario no encontrado.");
            }

            // Crear nueva reserva asociada al usuario
            var nuevaReserva = new Reserva
            {
                UsuarioEmail = usuarioEmail,
                Usuario = usuario,
                CantPersonas = cantPersonas,
                FechaReserva = FechaReserva,
                Confirmada = false // Inicia como no confirmada
            };

            // Guardar la reserva en la base de datos
            _context.Reservas.Add(nuevaReserva);
            _context.SaveChanges();

            return Ok("Reserva creada con éxito.");
        }

        // GET: Reservas/Create
        public IActionResult Create()
        {
            return View();
        }

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

        public async Task<IActionResult> Cancelar(int? id)
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

            // Obtener lista de motivos de cancelación
            ViewBag.Motivos = await _context.MotivosCancelacion.ToListAsync();

            return View(reserva);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarCancelacion(int id, int motivoId, string? otroMotivo)
        {
            var reserva = await _context.Reservas.FindAsync(id);

            if (reserva == null)
            {
                return NotFound();
            }

            reserva.EstaCancelada = true;
            reserva.MotivoCancelacionId = motivoId;
            reserva.MotivoCancelacionOtro = otroMotivo;

            try
            {
                
                await _context.SaveChangesAsync();
                TempData["Message"] = "La reserva ha sido cancelada exitosamente.";
            }
            catch (Exception ex)
            {
                
                TempData["Error"] = $"Hubo un error al cancelar la reserva: {ex.Message}";
            }


            return RedirectToAction("Menu", "Home");
        }
    }
}




