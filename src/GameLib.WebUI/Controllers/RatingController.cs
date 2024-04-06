using Microsoft.AspNetCore.Mvc;

namespace GameLib.WebUI.Controllers
{
    public class RatingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
