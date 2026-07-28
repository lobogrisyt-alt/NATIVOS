using Microsoft.AspNetCore.Mvc;

namespace NATIVOS.Controllers
{
    public class TradicionesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
