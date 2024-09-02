using Microsoft.AspNetCore.Mvc;
using PociDelivery.Interfaces;
using PociDelivery.Models;

namespace PociDelivery.Controllers
{
    public class RoliController : Controller
    {
        private readonly IRoliRepository _roliRepository;
        public RoliController(IRoliRepository roliRepository)
        {
            _roliRepository = roliRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Roli> roli = await _roliRepository.GetAllRolet();
            return View(roli);
        }
    }
}
