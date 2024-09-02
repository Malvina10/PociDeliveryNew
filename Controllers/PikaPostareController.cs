using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PociDelivery.Interfaces;
using PociDelivery.Models;
using PociDelivery.Repository;
using PociDelivery.ViewModels;

namespace PociDelivery.Controllers
{
    public class PikaPostareController : Controller
    {
        private readonly IPikaPostareRepository _pikaPostareRepository;
        public PikaPostareController(IPikaPostareRepository pikaPostareRepository)
        {
            _pikaPostareRepository = pikaPostareRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<PikaPostare> pikaPostare = await _pikaPostareRepository.GetAllPikaPostare();
            return View(pikaPostare);
        }

        public IActionResult ShtoPikePostare()
        {
            return View();
        }

        [HttpPost]

        public IActionResult ShtoPikePostare(PikaPostare pika)
        {
            if (!ModelState.IsValid)
            {
                return  View(pika);
            }

            _pikaPostareRepository.Add(pika);
            return RedirectToAction("Index");
        }

        /*public async Task<PikaPostare> ModifikoPikePostare(int id)
        {
            var pikaPostare = _pikaPostareRepository.GetByIdAsync(id);
            if (pikaPostare == null) return View();
            var pikaVM= new ModifikoPikePostareViewModel
            {
               
            }

            return View(pikaVM); 
        }*/
    }
}
