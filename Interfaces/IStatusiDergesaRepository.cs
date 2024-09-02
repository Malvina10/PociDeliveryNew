using PociDelivery.Models;

namespace PociDelivery.Interfaces
{
    public interface IStatusiDergesaRepository
    {
        Task<IEnumerable<StatusiDergesa>> GetAllStatusetDergesa();
        Task<StatusiDergesa> GetByIdAsync(int Id);
        bool Add(int IDStatusi, int IDDergesa,DateTime data, int fshire);

        bool Update(StatusiDergesa statusiDergesa);

        bool Delete(StatusiDergesa statusiDergesa);
        bool Save();
    }
}
