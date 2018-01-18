using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private HaarlemFilmDBContext db = new HaarlemFilmDBContext();

        public void AddBestelling(Bestelling basket, Kaartje kaartje, bool bestellingActief)
        {
            if (!bestellingActief)
            {
                using (db)
                {
                    db.Bestelling.Add(basket);
                    db.SaveChanges();
                }
                AddKlant(basket);
            }

            AddKaartje(basket, kaartje);
        }

        public void AddKaartje(Bestelling basket, Kaartje kaartje)
        { 
            using (db)
            {
                db.Kaartjes.Add(kaartje);
                db.SaveChanges();
            }
        }

        public void AddKlant(Bestelling basket)
        {
            using (db)
            {
                db.Klants.Add(basket.Klant);
                // executes the commands to implement the changes to the database
                db.SaveChanges();
            }
        }

        public void EditKaartje(Bestelling basket)
        {
            throw new NotImplementedException();
        }

        public Bestelling GetAllBestellingInfo(int? bestellingId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Bestelling> GetAllBestellings()
        {
            IEnumerable<Bestelling> bestellings;

            bestellings = (from bestelling in db.Bestelling
                                       select bestelling).ToList();

            return bestellings;
        }


        public void RemoveBestelling(Bestelling basket)
        {
            throw new NotImplementedException();
        }

        public void RemoveKaartje(Bestelling basket)
        {
            throw new NotImplementedException();
        }

        public void RemoveKlant(Bestelling basket)
        {
            throw new NotImplementedException();
        }
    }
}