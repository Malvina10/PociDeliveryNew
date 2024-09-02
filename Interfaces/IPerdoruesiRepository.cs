using Microsoft.AspNetCore.Identity;
using PociDelivery.Models;

namespace PociDelivery.Interfaces
{
    public interface IPerdoruesiRepository
    {
        Task<IEnumerable<Perdoruesi>> GetAllPerdoruesit();
        Task<Perdoruesi> GetByIdAsync(int id);
        Task<IEnumerable<Perdoruesi>> GetPerdoruesiByUsername(string username, string password );
        Task<IEnumerable<Perdoruesi>> GetPerdoruesitByPikaPostare(int IDPikaPostare);

        Task<IEnumerable<Perdoruesi>> GetPerdoruesitbyRole(int IDRoli);

        bool Add(Perdoruesi perdoruesi);
        bool Update(Perdoruesi perdoruesi);
        bool Delete(Perdoruesi perdoruesi);
        bool Save();

    }
}
