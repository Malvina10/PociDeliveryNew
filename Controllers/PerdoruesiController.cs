using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PociDelivery.Data;
using PociDelivery.Interfaces;
using PociDelivery.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PociDelivery.Controllers
{
    public class PerdoruesiController : Controller
    {
        private readonly IPerdoruesiRepository _perdoruesiRepository;
        private readonly IRoliRepository _roliRepository;  // New repository for handling roles
        private readonly IPikaPostareRepository _pikaPostareRepository;  // New repository for handling postal points

        public PerdoruesiController(IPerdoruesiRepository perdoruesiRepository,
                                     IRoliRepository roliRepository,
                                     IPikaPostareRepository pikaPostareRepository)
        {
            _perdoruesiRepository = perdoruesiRepository;
            _roliRepository = roliRepository;
            _pikaPostareRepository = pikaPostareRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Perdoruesi> perdoruesi = await _perdoruesiRepository.GetAllPerdoruesit();

            return View(perdoruesi);
        }

        //ShtoPerdorues View 
        public async Task<IActionResult> ShtoPerdorues()
        {
            var rolet = await _roliRepository.GetAllRolet();  // merr rolet
            ViewBag.RolesSelectList = new SelectList(rolet, "IDRoli", "EmerRoli");

            var pikatPostare = await _pikaPostareRepository.GetAllPikaPostare();  // merr pikat postare
            ViewBag.PikatSelectList = new SelectList(pikatPostare, "IDPikaPostare", "Pikapostare");

            return View();
        }


        [HttpPost] //ShtoPerdorues
        public async Task<IActionResult> ShtoPerdorues(Perdoruesi perdoruesi)
        {
            if (!ModelState.IsValid)
            {
                var rolet = await _roliRepository.GetAllRolet();
                ViewBag.RolesSelectList = new SelectList(rolet, "IDRoli", "EmerRoli");

                var pikatPostare = await _pikaPostareRepository.GetAllPikaPostare();
                ViewBag.PikatSelectList = new SelectList(pikatPostare, "IDPikaPostare", "Pikapostare");

                return View(perdoruesi);
            }

             _perdoruesiRepository.Add(perdoruesi);
            return RedirectToAction("Index");
        }


        //view per te shikuar detajet e nje perdoruesi 
        public async Task<IActionResult> DetajetPerdorues(int id)
        {
            return View();
        }
    }
}
