using Microsoft.AspNetCore.Mvc;
using NATIVOS.Data;
using NATIVOS.Models;

namespace NATIVOS.Controllers
{
    public class ExperienciasController : Controller
    {
        private readonly NATIVOSContext _context;

        public ExperienciasController(NATIVOSContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Mapa(string lugar)
        {
            ViewBag.Lugar = lugar;
            return View();
        }

        // Mostrar formulario de reserva
        [HttpGet]
        public IActionResult Reservar(string lugar)
        {
            ViewBag.Lugar = lugar;

            return View(new Reserva());
        }

        // Guardar reserva en la base de datos
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Reservar(
     string Nombre,
     string Apellido,
     string Correo,
     string Telefono,
     DateTime FechaVisita,
     int CantidadPersonas,
     string? Observaciones)
        {
            var reserva = new Reserva
            {
                IdExperiencia = null,
                IdUsuario = null,
                Nombre = Nombre,
                Apellido = Apellido,
                Correo = Correo,
                Telefono = Telefono,
                FechaReserva = DateTime.Now,
                FechaVisita = FechaVisita,
                CantidadPersonas = CantidadPersonas,
                Total = 0,
                Estado = "Pendiente",
                Observaciones = Observaciones
            };

            _context.Reservas.Add(reserva);
            _context.SaveChanges();

            return RedirectToAction("ReservaConfirmada");
        }

        public IActionResult ReservaConfirmada()
        {
            return View();
        }
    }
}



