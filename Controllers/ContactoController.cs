using Microsoft.AspNetCore.Mvc;

namespace NATIVOS.Controllers
{
    public class ContactoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
