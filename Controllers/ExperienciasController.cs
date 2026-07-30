using Microsoft.AspNetCore.Mvc;

namespace NATIVOS.Controllers
{
    public class ExperienciasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // Mapa interactivo
        public IActionResult Mapa(string lugar)
        {
            ViewBag.Lugar = lugar;
            return View();
        }
        public IActionResult Reservar(string lugar)
        {
            ViewBag.Lugar = lugar;
            return View();
        }
    }
}