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
        void AddBestelling(Bestelling basket, Kaartje kaartje, bool bestellingActief);
        void AddKaartje(Bestelling basket, Kaartje kaartje);
        void AddKlant(Bestelling basket);

        Bestelling GetAllBestellingInfo(int? bestellingId);
        IEnumerable<Bestelling> GetAllBestellings();

        void EditKaartje(Bestelling basket);

        void RemoveKaartje(Bestelling basket);
        void RemoveBestelling(Bestelling basket);
        void RemoveKlant(Bestelling basket);
    }
}
