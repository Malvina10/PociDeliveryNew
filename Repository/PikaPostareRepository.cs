using Microsoft.EntityFrameworkCore;
using PociDelivery.Data;
using PociDelivery.Interfaces;
using PociDelivery.Models;

namespace PociDelivery.Repository
{
    public class PikaPostareRepository : IPikaPostareRepository
    {
        private readonly ApplicationDbContext _context;
        public PikaPostareRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(PikaPostare pikaPostare)
        {
            _context.Add(pikaPostare);
            return Save();
        }

        public bool Delete(PikaPostare pikaPostare)
        {
            _context.Remove(pikaPostare);
            return Save();
        }

        public async Task<IEnumerable<PikaPostare>> GetAllPikaPostare()
        {
            return await _context.PikatPostare.ToListAsync();
        }

        public async Task<PikaPostare> GetByIdAsync(int Id)
        {
            return await _context.PikatPostare.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PikaPostare>> GetPikaPostareByStatus(byte statusi)
        {
            return await _context.PikatPostare.Where(i => i.Statusi == statusi).ToListAsync();
        }

        public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0 ? true : false;
        }

        public bool Update(PikaPostare pikaPostare)
        {
            _context.Update(pikaPostare);
            return Save();
        }
    }
}
