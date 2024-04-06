using Microsoft.AspNetCore.Mvc;

namespace GameLib.WebUI.Controllers
{
    public class DeveloperController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
