using Microsoft.EntityFrameworkCore;
using PociDelivery.Data;
using PociDelivery.Interfaces;
using PociDelivery.Models;

namespace PociDelivery.Repository
{
    public class StatusiRepository : IStatusiRepository
    {
        private readonly ApplicationDbContext _context;
        public StatusiRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Statusi statusi)
        {
            _context.Add(statusi);
            return Save();
        }

        public bool Delete(Statusi statusi)
        {
            _context.Remove(statusi);
            return Save();
        }

        public async Task<IEnumerable<Statusi>> GetAllStatuset()
        {
            return await _context.Statuset.ToListAsync();
        }

        public Task<Statusi> GetByIdAsync(int Id)
        {
            return _context.Statuset.FirstOrDefaultAsync();
        }

        public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0 ? true : false;
        }

        public bool Update(Statusi statusi)
        {
            _context.Update(statusi);
            return Save();
        }
    }
}
