using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PociDelivery.Interfaces;
using PociDelivery.Models;
using PociDelivery.Repository;

namespace PociDelivery.Controllers
{
    public class ZonaMbulimitController : Controller
    {
        private readonly IZonaMbulimitRepository _zonaMbulimitRepository;
        private readonly IPikaPostareRepository _pikaPostareRepository;
        public ZonaMbulimitController(IZonaMbulimitRepository zonaMbulimitRepository,IPikaPostareRepository pikaPostareRepository)
        {
            _zonaMbulimitRepository = zonaMbulimitRepository;
            _pikaPostareRepository = pikaPostareRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<ZonaMbulimit> zonaMbulimi = await _zonaMbulimitRepository.GetAllZonaMbulimi();
            return View(zonaMbulimi);
        }

        public async Task<IActionResult> ShtoZoneMbulimi()
        {
            var pikatPostare = await _pikaPostareRepository.GetAllPikaPostare();  // Fetch postal points via repository
            ViewBag.PikatSelectList = new SelectList(pikatPostare, "IDPikaPostare", "Pikapostare");
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> ShtoZoneMbulimi(ZonaMbulimit zonambulimit)
        {
            if (!ModelState.IsValid)
            {
                var pikatPostare = await _pikaPostareRepository.GetAllPikaPostare();  // Fetch postal points via repository
                ViewBag.PikatSelectList = new SelectList(pikatPostare, "IDPikaPostare", "Pikapostare");
                return View(zonambulimit);
            }

            _zonaMbulimitRepository.Add(zonambulimit);
            return RedirectToAction("Index");
        }
    }
}
