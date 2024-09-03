using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PociDelivery.Interfaces;
using PociDelivery.Models;
using PociDelivery.Repository;
using PociDelivery.ViewModels;
using System.Data;

namespace PociDelivery.Controllers
{
    public class PikaPostareController : Controller
    {
        private readonly IPikaPostareRepository _pikaPostareRepository;
        public PikaPostareController(IPikaPostareRepository pikaPostareRepository)
        {
            _pikaPostareRepository = pikaPostareRepository;
        }

        [Authorize(Roles = "Administratori")]
        public async Task<IActionResult> Index()
        {
            IEnumerable<PikaPostare> pikaPostare = await _pikaPostareRepository.GetAllPikaPostare();
            return View(pikaPostare);
        }

        [Authorize(Roles = "Administratori")]
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

     //view per mbylljen e nje pike postare 
     public async Task<IActionResult> ModifikoPikePostare(int id)
        {
            return  View();
        }
   
    }
}
