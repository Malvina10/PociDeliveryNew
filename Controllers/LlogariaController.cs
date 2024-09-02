using Microsoft.AspNetCore.Mvc;

namespace PociDelivery.Controllers
{
    public class LlogariaController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
