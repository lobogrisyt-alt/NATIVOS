using Microsoft.AspNetCore.Mvc;

namespace NATIVOS.Controllers
{
    public class SobrenosotrosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
