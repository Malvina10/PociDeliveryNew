using Microsoft.EntityFrameworkCore;
using PociDelivery.Data;
using PociDelivery.Interfaces;
using PociDelivery.Models;

namespace PociDelivery.Repository
{
    public class ZonaMbulimitRepository : IZonaMbulimitRepository
    {
        private readonly ApplicationDbContext _context;
        public ZonaMbulimitRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(ZonaMbulimit zonaMbulimi)
        {
            _context.Add(zonaMbulimi);
            return Save();
        }

        public bool Delete(ZonaMbulimit zonaMbulimi)
        {
            _context.Remove(zonaMbulimi);
            return Save();
        }

        public async Task<IEnumerable<ZonaMbulimit>> GetAllZonaMbulimi()
        {
            return await _context.ZonatMbulimit.Include(z=>z.PikaPostare).ToListAsync();
        }
        
        public async Task<ZonaMbulimit> GetByIdAsync(int IDZona)
        {
            return await _context.ZonatMbulimit.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ZonaMbulimit>> GetZonaMbulimiByIDPikaPostare(int IDPikaPostare)
        {
            return await _context.ZonatMbulimit.Where(i => i.PikaPostare.IDPikaPostare == IDPikaPostare).ToListAsync();

        }

        public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0 ? true : false;  
        }

        public bool Update(ZonaMbulimit zonaMbulimi)
        {
            _context.Update(zonaMbulimi);
            return Save();
        }
    }
}
