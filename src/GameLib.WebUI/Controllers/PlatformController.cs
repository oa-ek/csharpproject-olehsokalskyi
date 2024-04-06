using Microsoft.AspNetCore.Mvc;

namespace GameLib.WebUI.Controllers
{
    public class PlatformController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
