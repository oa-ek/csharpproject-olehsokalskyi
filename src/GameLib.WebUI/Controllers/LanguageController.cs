using Microsoft.AspNetCore.Mvc;

namespace GameLib.WebUI.Controllers
{
    public class LanguageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
