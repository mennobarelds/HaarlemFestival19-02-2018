using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IBasketRepository
    {
        Bestelling AddBestelling(Kaartje kaartje);
        void AddKaartje(Kaartje kaartje);
        int AddKlant();

        Bestelling GetAllBestellingInfo(int? bestellingId);
        IEnumerable<Kaartje> GetAllKaartjes(int bestellingId);

        void EditKaartje(Bestelling basket);
        void PayBestelling(int bestelId);
        void RemoveKaartje(Bestelling basket);
        void RemoveBestelling(Bestelling basket);

        string GetBestelcode();
        int GetBestelIdByCode(string bestelcode);
        string GetBestelcode(int bestellingId);
        string CreateBestelcode();
        bool BestelcodeExists(string bestelcode);
    }
}
