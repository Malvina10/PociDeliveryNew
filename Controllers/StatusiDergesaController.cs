using Microsoft.AspNetCore.Mvc;
using PociDelivery.Data;
using PociDelivery.Interfaces;

namespace PociDelivery.Controllers
{
    public class StatusiDergesaController : Controller
    {
        private readonly IStatusiDergesaRepository _statusiDergesaRepository; 

        public StatusiDergesaController(IStatusiDergesaRepository statusiDergesaRepository)
        {
            _statusiDergesaRepository = statusiDergesaRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
