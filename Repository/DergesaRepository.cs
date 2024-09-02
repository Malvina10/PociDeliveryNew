using Microsoft.EntityFrameworkCore;
using PociDelivery.Data;
using PociDelivery.Interfaces;
using PociDelivery.Models;

namespace PociDelivery.Repository
{
    public class DergesaRepository : IDergesaRepository
    {
        private readonly ApplicationDbContext _context;
        public DergesaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Dergesa dergesa)
        {
            _context.Add(dergesa);
            return Save();
        }

        public bool Delete(Dergesa dergesa)
        {
            _context.Remove(dergesa);
            return Save();
        }

        public async Task<IEnumerable<Dergesa>> GetAllDergesat()
        {
            return await _context.Dergesat.Include(p=>p.Klient).ToListAsync();
        }

        public async Task<Dergesa> GetByIdAsync(int Id)
        {
            return await _context.Dergesat.FirstOrDefaultAsync();
        }

        public async Task<Dergesa> GetDergesaByBarcode(string Barcode)
        {
            return await _context.Dergesat.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Dergesa>> GetDergesaByIDKlienti(int IDKlienti)
        {
            return await _context.Dergesat.Where(i => i.Klient.IDPerdoruesi == IDKlienti).ToListAsync();
        }

        public async Task<IEnumerable<Dergesa>> GetDergesaByIdSportelisti(int IDSportelisti)
        {
            return await _context.Dergesat.Where(i => i.Sportelist.IDPerdoruesi == IDSportelisti).ToListAsync();
        }

        public async Task<IEnumerable<Dergesa>> GetDergesaByPikaPostare(int IDPikaPostare)
        {
            return await _context.Dergesat.Where(i => i.PikaPostare.IDPikaPostare == IDPikaPostare).ToListAsync();
        }

        public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0 ? true : false; 
        }

        public bool Update(Dergesa dergesa)
        {
            _context.Update(dergesa);
            return Save();
        }
    }
}
