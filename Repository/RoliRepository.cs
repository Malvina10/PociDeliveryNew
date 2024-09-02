using Microsoft.EntityFrameworkCore;
using PociDelivery.Data;
using PociDelivery.Interfaces;
using PociDelivery.Models;

namespace PociDelivery.Repository
{
    public class RoliRepository : IRoliRepository
    {
        private readonly ApplicationDbContext _context;
        public RoliRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Roli roli)
        {
            _context.Add(roli);
            return Save();
        }

        public bool Delete(Roli roli)
        {
            _context.Remove(roli);
            return Save();
        }

        public async Task<IEnumerable<Roli>> GetAllRolet()
        {
            return await _context.Rolet.ToListAsync();
        }

        public async Task<Roli> GetByIdAsync(int Id)
        {
  
            return await _context.Rolet.FirstOrDefaultAsync(r => r.IDRoli == Id);
        }
        public async Task<int> GetRoleIdByName(string roleName)
        {
            var role = await _context.Rolet.FirstOrDefaultAsync(r => r.EmerRoli == roleName);

            return role.IDRoli;
        }


        public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0 ? true : false;
        }

        public bool Update(Roli roli)
        {
            _context.Update(roli);
            return Save();
        }
    }
}
