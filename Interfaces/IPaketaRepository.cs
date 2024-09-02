using PociDelivery.Models;

namespace PociDelivery.Interfaces
{
    public interface IPaketaRepository
    {
        Task<IEnumerable<Paketa>> GetAllPaketat();
        Task<Paketa> GetBGyIdAsync(int Id);
        Task<Paketa> GetPaketaByBarcode(string barcode);
        Task<IEnumerable<Paketa>> GetPaketatByIDTransportuesi(int IdTransportuesi);
        Task<IEnumerable<Paketa>> GetPaketaByIdPikaPostareFillim(int IDPikaPostareFillim);
        Task<IEnumerable<Paketa>> GetPaketaByIdPikaPostareFund(int IDPikaPostareFund);

        bool Add(Paketa paketa);
        bool Update(Paketa paketa);
        bool Delete(Paketa paketa);
        bool  Save(); 
    }
}
