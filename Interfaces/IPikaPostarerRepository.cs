using PociDelivery.Models;

namespace PociDelivery.Interfaces
{
    public interface IPikaPostareRepository
    {
        Task<IEnumerable<PikaPostare>> GetAllPikaPostare();
        Task<PikaPostare> GetByIdAsync(int Id);

        Task<IEnumerable<PikaPostare>> GetPikaPostareByStatus(byte statusi);

        bool Add(PikaPostare pikaPostare);
        bool Update(PikaPostare pikaPostare);
        bool Delete(PikaPostare pikaPostare);
        bool Save();
    }
}
