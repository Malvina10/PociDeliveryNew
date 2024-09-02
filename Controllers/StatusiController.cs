using Microsoft.AspNetCore.Mvc;
using PociDelivery.Interfaces;
using PociDelivery.Models;

namespace PociDelivery.Controllers
{
    public class StatusiController : Controller
    {
        private readonly IStatusiRepository _statusiRepository;
        public StatusiController(IStatusiRepository statusiRepository)
        {
            _statusiRepository = statusiRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Statusi> statusi =await  _statusiRepository.GetAllStatuset();
            return View(statusi);
        }
    }
}
