using Microsoft.EntityFrameworkCore;
using PociDelivery.Data;
using PociDelivery.Interfaces;
using PociDelivery.Models;

namespace PociDelivery.Repository
{
    public class StatusiPaketaRepository : IStatusiPaketaRepository
    {
        private readonly ApplicationDbContext _context;
        public StatusiPaketaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(int IDStatusi, int IDPaketa, DateTime data, int fshire)
        {
            StatusiPaketa statusiPaketa = new StatusiPaketa();
            statusiPaketa.IDStatusi = IDStatusi;
            statusiPaketa.IDPaketa = IDPaketa;
            statusiPaketa.CreatedOn = data;
            statusiPaketa.Fshire = (byte)fshire;

            _context.Add(statusiPaketa);
            return Save();
        }

        public bool Delete(StatusiPaketa statusiPaketa)
        {
            _context.Remove(statusiPaketa);
            return Save();
        }

        public async Task<IEnumerable<StatusiPaketa>> GetAllStatusetPaketa()
        {
            return await _context.StatusetPaketa.ToListAsync();
        }

        public Task<StatusiPaketa> GetByIdAsync(int Id)
        {
            return _context.StatusetPaketa.FirstOrDefaultAsync();
        }

        public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0 ? true : false;
        }

        public bool Update(StatusiPaketa statusiPaketa)
        {
            _context.Update(statusiPaketa);
            return Save();
        }
    }
}
