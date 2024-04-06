using Microsoft.AspNetCore.Mvc;

namespace GameLib.WebUI.Controllers
{
    public class PublisherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
