using Microsoft.AspNetCore.Mvc;

namespace GameLib.WebUI.Controllers
{
    public class GenreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
