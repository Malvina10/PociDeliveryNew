using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PociDelivery.Interfaces;
using PociDelivery.Models;
using PociDelivery.Repository;

namespace PociDelivery.Controllers
{
    public class PaketaController : Controller
    {
        private readonly IPaketaRepository _paketaRepository;
        private readonly IStatusiRepository _statusiRepository;
        private readonly IPerdoruesiRepository _perdoruesiRepository;
        private readonly IRoliRepository _roliRepository;
        private readonly IPikaPostareRepository _pikaPostareRepository;
        private readonly IStatusiPaketaRepository _statusiPaketaRepository;
    
        public PaketaController(IPaketaRepository paketaRepository,IStatusiRepository statusiRepository, IPerdoruesiRepository perdoruesiRepository, IRoliRepository roliRepository,IPikaPostareRepository pikaPostareRepository,IStatusiPaketaRepository statusiPaketaRepository)
        {
            _paketaRepository = paketaRepository;
            _statusiRepository = statusiRepository;
            _perdoruesiRepository = perdoruesiRepository;
            _roliRepository = roliRepository;
            _pikaPostareRepository = pikaPostareRepository;
            _statusiPaketaRepository = statusiPaketaRepository;
        }

        //do perdoret per te gjeneruar barcode-in me 10 shifra
        public static string GjeneroBarcodeRandom(int length)
        {
            Random random = new Random();
            string barcode = "";

            for (int i = 0; i < length; i++)
            {
                barcode += random.Next(0, 10); // Generates a random number between 0 and 9
            }

            return barcode;
        }


        public async Task<IActionResult> Index()
        {
            IEnumerable<Paketa> paketa = await _paketaRepository.GetAllPaketat();
            return View(paketa);
        }

        public async Task<IActionResult> ShtoPakete()
        {
            //do te gjenerohet barcode qe te kaloj me pas te view 
            string BarcodeGenerated = GjeneroBarcodeRandom(10);
            ViewBag.GeneratedBarcode = BarcodeGenerated;

            //do te merren statuset per dergesen , e cila by default do jete Regjistruar
            var statuset = await _statusiRepository.GetAllStatuset();
            ViewBag.StatusetSelectList = new SelectList(statuset, "IDStatusi", "EmerStatusi");

            //do te merren perdoruesit qe kane rolin transportues 
            var roliTransportues = await _roliRepository.GetRoleIdByName("Transportuesi");
            if (roliTransportues == null)
            {
                return View();
            }
            else
            {
                var transportuesi = await _perdoruesiRepository.GetPerdoruesitbyRole(roliTransportues);
                ViewBag.TransportuesiSelectList = new SelectList(transportuesi, "IDPerdoruesi", "Username");

            }


            var pikatPostare = await _pikaPostareRepository.GetAllPikaPostare();  // Merr pika postare
            ViewBag.PikatSelectList = new SelectList(pikatPostare, "IDPikaPostare", "Pikapostare");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ShtoPakete(Paketa paketa)
        {
            if (!ModelState.IsValid)
            {
                //do te gjenerohet barcode qe te kaloj me pas te view 
                string BarcodeGenerated = GjeneroBarcodeRandom(10);
                ViewBag.GeneratedBarcode = BarcodeGenerated;

                //do te merren statuset per dergesen , e cila by default do jete Regjistruar
                var statuset = await _statusiRepository.GetAllStatuset();
                ViewBag.StatusetSelectList = new SelectList(statuset, "IDStatusi", "EmerStatusi");

                //do te merren perdoruesit qe kane rolin transportues 
                var roliTransportues = await _roliRepository.GetRoleIdByName("Transportuesi");
                if (roliTransportues == null)
                {
                    return View();
                }
                else
                {
                    var transportuesi = await _perdoruesiRepository.GetPerdoruesitbyRole(roliTransportues);
                    ViewBag.TransportuesiSelectList = new SelectList(transportuesi, "IDPerdoruesi", "Username");

                }


                var pikatPostare = await _pikaPostareRepository.GetAllPikaPostare();  // Merr pika postare
                ViewBag.PikatSelectList = new SelectList(pikatPostare, "IDPikaPostare", "Pikapostare");

                return View(paketa);
            }


            var shtimPakete = _paketaRepository.Add(paketa);
            if (shtimPakete == true)
            {
                bool shtimStatusPakete = _statusiPaketaRepository.Add(1, paketa.IDPaketa, paketa.CreatedOn, 2);
                if (shtimStatusPakete == true)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(paketa);

        }

        //do te shfaqet view Detajet 
        public async Task<IActionResult> Detajet(int id)
        {
            //var paketa= await _paketaRepository.GetBGyIdAsync(id);
            return View();
        }

    }
}
