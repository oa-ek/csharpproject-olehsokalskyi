using Microsoft.AspNetCore.Mvc;

namespace GameLib.WebUI.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
