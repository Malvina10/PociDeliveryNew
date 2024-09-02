
using PociDelivery.Models;

namespace PociDelivery.Interfaces
{
    public interface IZonaMbulimitRepository
    {
        Task<IEnumerable<ZonaMbulimit>> GetAllZonaMbulimi();
        Task<ZonaMbulimit> GetByIdAsync(int IDZona);
        Task<IEnumerable<ZonaMbulimit>> GetZonaMbulimiByIDPikaPostare(int IDPikaPostare);

        bool Add(ZonaMbulimit zonaMbulimi);
        bool Update(ZonaMbulimit zonaMbulimi);
        bool Delete(ZonaMbulimit zonaMbulimi);
        bool Save();
    }
}
