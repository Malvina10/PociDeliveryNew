using PociDelivery.Models;

namespace PociDelivery.Interfaces
{
    public interface IStatusiRepository
    {
        Task<IEnumerable<Statusi>> GetAllStatuset();
        Task<Statusi> GetByIdAsync(int Id);
        bool Add(Statusi statusi);

        bool Update(Statusi statusi);

        bool Delete(Statusi statusi);
        bool Save(); 

    }
}
