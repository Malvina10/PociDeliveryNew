using PociDelivery.Models;

namespace PociDelivery.Interfaces
{
    public interface IDergesaRepository
    {
        Task<IEnumerable<Dergesa>> GetAllDergesat();

        Task<Dergesa> GetByIdAsync(int Id);
        Task<Dergesa> GetDergesaByBarcode(string Barcode);

        Task<IEnumerable<Dergesa>> GetDergesaByIDKlienti(int IDKlienti);
        Task<IEnumerable<Dergesa>> GetDergesaByIdSportelisti(int IDSportelisti);

        Task<IEnumerable<Dergesa>> GetDergesaByPikaPostare(int IDPikaPostare);
        bool Add(Dergesa dergesa);
        bool Update(Dergesa dergesa);
        bool Delete(Dergesa dergesa);
        bool Save();
  

    }
}
