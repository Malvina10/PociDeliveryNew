using Microsoft.EntityFrameworkCore;
using PociDelivery.Data;
using PociDelivery.Interfaces;
using PociDelivery.Models;


namespace PociDelivery.Repository
{
    public class PerdoruesiRepository : IPerdoruesiRepository
    {
        private readonly ApplicationDbContext _context; 
        public PerdoruesiRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Perdoruesi perdoruesi)
        {
            _context.Add(perdoruesi);
            return Save();

        }

        public bool Delete(Perdoruesi perdoruesi)
        {
            _context.Remove(perdoruesi);
            return Save();

        }

        public async Task<IEnumerable<Perdoruesi>> GetAllPerdoruesit()
        {
            return await _context.Perdoruesit.Include(p => p.Roli).ToListAsync();
        }

        public async Task<Perdoruesi> GetByIdAsync(int id)
        {
            return await _context.Perdoruesit.FirstOrDefaultAsync(i => i.IDPerdoruesi==id);
        }

        public async Task<IEnumerable<Perdoruesi>> GetPerdoruesiByUsername(string username, string password)
        {
            return await _context.Perdoruesit.Where(i => i.Username.Contains(username) && i.Fjalekalimi.Contains(password)).ToListAsync();
        }

        public async Task<IEnumerable<Perdoruesi>> GetPerdoruesitByPikaPostare(int IDPikaPostare)
        {
            return await _context.Perdoruesit.Where(i => i.PikaPostare.IDPikaPostare == IDPikaPostare).ToListAsync();
        }

        public async  Task<IEnumerable<Perdoruesi>> GetPerdoruesitbyRole(int IDRoli)
        {
            return await _context.Perdoruesit.Where(i => i.Roli.IDRoli == IDRoli).ToListAsync();
        }

        public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0 ? true : false;
        }

        public bool Update(Perdoruesi perdoruesi)
        {
            _context.Update(perdoruesi);
            return Save();
        }
    }
}
