using Microsoft.AspNetCore.Mvc;

namespace GameLib.WebUI.Controllers
{
    public class AchievementUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
