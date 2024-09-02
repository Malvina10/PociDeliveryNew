using Microsoft.EntityFrameworkCore;
using PociDelivery.Data;
using PociDelivery.Interfaces;
using PociDelivery.Models;

namespace PociDelivery.Repository
{
    public class ReportiRepository : IReportRepository
    {
        private readonly ApplicationDbContext _context;
        public ReportiRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Reporti reporti)
        {
            _context.Add(reporti);
            return Save();
        }

        public bool Delete(Reporti reporti)
        {
            _context.Remove(reporti);
            return Save();
        }

        public async Task<IEnumerable<Reporti>> GetAllReportet()
        {
            return await _context.Reportet.ToListAsync();  
        }

        public async Task<Reporti> GetByIdAsync(int Id)
        {
            return await _context.Reportet.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Reporti>> GetReportiByIDPerdorues(int IDPerdoruesi)
        {
            return await _context.Reportet.Where(i => i.Perdoruesi.IDPerdoruesi==IDPerdoruesi).ToListAsync();
        }

        public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0 ? true : false;
        }

        public bool Update(Reporti reporti)
        {
            _context.Update(reporti);
            return Save();
        }
    }
}
