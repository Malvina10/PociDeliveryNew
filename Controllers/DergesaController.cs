using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PociDelivery.Interfaces;
using PociDelivery.Models;
using PociDelivery.Repository;
using System.Net.NetworkInformation;

namespace PociDelivery.Controllers
{
    public class DergesaController : Controller
    {
        private readonly IDergesaRepository _dergesaRepository;
        private readonly IPerdoruesiRepository _perdoruesiRepository;
        private readonly IPikaPostareRepository _pikaPostareRepository;
        private readonly IRoliRepository _roliRepository;
        private readonly IStatusiRepository _statusiRepository;
        private readonly IStatusiDergesaRepository _statusiDergesaRepository;

        public DergesaController(IDergesaRepository dergesaRepository,IPerdoruesiRepository perdoruesiRepository,IPikaPostareRepository pikaPostareRepository,IRoliRepository roliRepository,IStatusiRepository statusiRepository,IStatusiDergesaRepository statusiDergesaRepository)
        {
            _dergesaRepository = dergesaRepository;
            _perdoruesiRepository = perdoruesiRepository;
            _pikaPostareRepository = pikaPostareRepository;
            _roliRepository = roliRepository;
            _statusiRepository = statusiRepository;
            _statusiDergesaRepository = statusiDergesaRepository;
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
            IEnumerable<Dergesa> dergesa = await _dergesaRepository.GetAllDergesat();
            return View(dergesa);
        }

        public async Task<IActionResult> ShtoDergese()
        {
            //do te gjenerohet barcode qe te kaloj me pas te view 
            string BarcodeGenerated = GjeneroBarcodeRandom(10);
            ViewBag.GeneratedBarcode = BarcodeGenerated;

            //do te merren statuset per dergesen , e cila by default do jete Regjistruar
            var statuset = await _statusiRepository.GetAllStatuset();
             ViewBag.StatusetSelectList = new SelectList(statuset, "IDStatusi", "EmerStatusi");
           
            //do te merren perdoruesit qe kane rolin sportelist 
            var roliSporteli = await _roliRepository.GetRoleIdByName("Sporteli");
            if (roliSporteli == null)
            {
                return View();
            }
            else
            {
                var sportelisti = await _perdoruesiRepository.GetPerdoruesitbyRole(roliSporteli);  
                ViewBag.SportelistiSelectList = new SelectList(sportelisti, "IDPerdoruesi", "Username");

            }

            //do te merren perdoruesit qe kane rolin e klientit. Nese klienti nuk gjendet ne sistem, atehere do te regjistrohet
            var roliKlient = await _roliRepository.GetRoleIdByName("Klienti");
            if (roliKlient == null)
            {
                return View();
            }
            else
            {
                var klienti = await _perdoruesiRepository.GetPerdoruesitbyRole(roliKlient);
                ViewBag.KlientiSelectList = new SelectList(klienti, "IDPerdoruesi", "Username");

            }

            var pikatPostare = await _pikaPostareRepository.GetAllPikaPostare();  // Merr pika postare
            ViewBag.PikatSelectList = new SelectList(pikatPostare, "IDPikaPostare", "Pikapostare");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ShtoDergese(Dergesa dergesa)
        {
            if (!ModelState.IsValid)
            {
                //do te gjenerohet barcode qe te kaloj me pas te view 
                string BarcodeGenerated = GjeneroBarcodeRandom(10);
                ViewBag.GeneratedBarcode = BarcodeGenerated;

                //do te merren statuset per dergesen , e cila by default do jete Regjistruar
                var statuset = await _statusiRepository.GetAllStatuset();
                ViewBag.StatusetSelectList = new SelectList(statuset, "IDStatusi", "EmerStatusi");

                //do te merren perdoruesit qe kane rolin sportelist 
                var roliSporteli = await _roliRepository.GetRoleIdByName("Sporteli");
                if (roliSporteli == null)
                {
                    return View(dergesa);
                }
                else
                {
                    var sportelisti = await _perdoruesiRepository.GetPerdoruesitbyRole(roliSporteli);  // Merr perdoruesit me rolin sportelist 
                    ViewBag.SportelistiSelectList = new SelectList(sportelisti, "IDPerdoruesi", "Username");

                }

                //do te merren perdoruesit qe kane rolin e klientit. Nese klienti nuk gjendet ne sistem, atehere do te regjistrohet
                var roliKlient = await _roliRepository.GetRoleIdByName("Klienti");
                if (roliKlient == null)
                {
                    return View();
                }
                else
                {
                    var klienti = await _perdoruesiRepository.GetPerdoruesitbyRole(roliKlient);
                    ViewBag.KlientiSelectList = new SelectList(klienti, "IDPerdoruesi", "Username");

                }


                var pikatPostare = await _pikaPostareRepository.GetAllPikaPostare();  // Merr pika postare
                ViewBag.PikatSelectList = new SelectList(pikatPostare, "IDPikaPostare", "Pikapostare");

                return View(dergesa);
            }

            var shtimDergese = _dergesaRepository.Add(dergesa);
            if (shtimDergese==true) 
            {
                bool shtimStatusDergese=_statusiDergesaRepository.Add(1, dergesa.IDDergesa,dergesa.CreatedOn,2);
                if (shtimStatusDergese==true )
                {
                    return RedirectToAction("Index");
                }
            }
            return View(dergesa);

        }
    }
}
