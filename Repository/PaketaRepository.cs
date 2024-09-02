using Microsoft.EntityFrameworkCore;
using PociDelivery.Data;
using PociDelivery.Interfaces;
using PociDelivery.Models;
using System.Data;

namespace PociDelivery.Repository
{
    public class PaketaRepository : IPaketaRepository
    {
        private readonly ApplicationDbContext _context;
        public PaketaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
   
        public bool Add(Paketa paketa)
        {
            _context.Add(paketa);
            return Save();
        }

        public bool Delete(Paketa paketa)
        {
            _context.Remove(paketa);
            return Save();
        }

        public async Task<IEnumerable<Paketa>> GetAllPaketat()
        {
            return await _context.Paketat.Include(p => p.Transportuesi).Include(p => p.PikaPostareFund).ToListAsync();
        }

        public async Task<Paketa> GetBGyIdAsync(int Id)
        {
            return await _context.Paketat.FirstOrDefaultAsync();
        }

        public async Task<Paketa> GetPaketaByBarcode(string barcode)
        {
            return await _context.Paketat.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Paketa>> GetPaketaByIdPikaPostareFillim(int IDPikaPostareFillim)
        {
            return await _context.Paketat.Where(i => i.PikaPostareFillim.IDPikaPostare==IDPikaPostareFillim).ToListAsync();
        }

        public async Task<IEnumerable<Paketa>> GetPaketaByIdPikaPostareFund(int IDPikaPostareFund)
        {
            return await _context.Paketat.Where(i => i.PikaPostareFund.IDPikaPostare == IDPikaPostareFund).ToListAsync();
        }

        public async Task<IEnumerable<Paketa>> GetPaketatByIDTransportuesi(int IdTransportuesi)
        {
            return await _context.Paketat.Where(i => i.Transportuesi.IDPerdoruesi == IdTransportuesi).ToListAsync();
        }

        public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0 ? true : false;
        }

        public bool Update(Paketa paketa)
        {
            _context.Update(paketa);
            return Save();
        }
    }
}
