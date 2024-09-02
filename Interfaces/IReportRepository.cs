using PociDelivery.Models;

namespace PociDelivery.Interfaces
{
    public interface IReportRepository
    {
        Task<IEnumerable<Reporti>> GetAllReportet();
        Task<Reporti> GetByIdAsync(int Id);
        Task<IEnumerable<Reporti>> GetReportiByIDPerdorues(int IDPerdoruesi);
        bool Add(Reporti reporti);
        bool Update(Reporti reporti);
        bool Delete(Reporti reporti);
        bool Save();


    }
}
