using Microsoft.AspNetCore.Mvc;
using PociDelivery.Interfaces;
using PociDelivery.Models;

namespace PociDelivery.Controllers
{
    public class ReportiController : Controller
    {
        private readonly IReportRepository _reportRepository;
        public ReportiController(IReportRepository reportiRepository)
        {
            _reportRepository = reportiRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Reporti> reporti = await _reportRepository.GetAllReportet();
            return View(reporti);
        }
    }
}
