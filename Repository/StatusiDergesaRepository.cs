using Microsoft.EntityFrameworkCore;
using PociDelivery.Data;
using PociDelivery.Interfaces;
using PociDelivery.Models;
using System.Net.NetworkInformation;

namespace PociDelivery.Repository
{
    public class StatusiDergesaRepository : IStatusiDergesaRepository
    {
        private readonly ApplicationDbContext _context;
        public StatusiDergesaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public  bool Add(int IDStatusi, int IDDergesa, DateTime data, int fshire)
        {
            StatusiDergesa statusiDergesa = new StatusiDergesa();
            statusiDergesa.IDStatusi = IDStatusi;
            statusiDergesa.IDDergesa = IDDergesa;
            statusiDergesa.Timestamp = data;
            statusiDergesa.Fshire = (byte)fshire;

            _context.Add(statusiDergesa);
            return Save();
        }

        public bool Delete(StatusiDergesa statusiDergesa)
        {
            _context.Remove(statusiDergesa);
            return Save();
        }

        public async Task<IEnumerable<StatusiDergesa>> GetAllStatusetDergesa()
        {
            return await _context.StatusetDergesa.ToListAsync();
        }

        public Task<StatusiDergesa> GetByIdAsync(int Id)
        {
            return _context.StatusetDergesa.FirstOrDefaultAsync();
        }

        public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0 ? true : false;
        }

        public bool Update(StatusiDergesa statusiDergesa)
        {
            _context.Update(statusiDergesa);
            return Save();
        }
    }
}
