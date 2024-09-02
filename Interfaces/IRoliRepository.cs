using PociDelivery.Models;

namespace PociDelivery.Interfaces
{
    public interface IRoliRepository
    {
        Task<IEnumerable<Roli>> GetAllRolet();
        Task<Roli> GetByIdAsync(int Id);
        Task<int> GetRoleIdByName(string roli);

        bool Add(Roli roli);
        bool Update(Roli roli);
        bool Delete(Roli roli);
        bool Save();
    }
}
