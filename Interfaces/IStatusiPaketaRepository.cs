using PociDelivery.Models;

namespace PociDelivery.Interfaces
{
    public interface IStatusiPaketaRepository
    {
        Task<IEnumerable<StatusiPaketa>> GetAllStatusetPaketa();
        Task<StatusiPaketa> GetByIdAsync(int Id);
        bool Add(int IDStatusi, int IDPaketa, DateTime data, int fshire);

        bool Update(StatusiPaketa statusiPaketa);

        bool Delete(StatusiPaketa statusiPaketa);
        bool Save();
    }
}
