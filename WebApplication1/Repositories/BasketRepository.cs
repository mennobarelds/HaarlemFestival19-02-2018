using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class BasketRepository : IBasketRepository
    {

        public Bestelling AddBestelling (Kaartje kaartje)
        {
            Bestelling basket = new Bestelling();
            if (HttpContext.Current.Session["BestelId"] == null) {
                
                using (HaarlemFilmDBContext db = new HaarlemFilmDBContext())
                {
                    int klantId = AddKlant();

                    basket.Betaald = false;
                    basket.BestelCode = GetBestelcode();
                    basket.TotaalPrijs = 10;
                    basket.KlantId = klantId;

                    basket = db.Bestelling.Add(basket);
                    db.SaveChanges();
                }

                HttpContext.Current.Session["BestelId"] = basket.BestellingId;
            }
            basket.Kaartjes = new List<Kaartje>();
            basket.BestellingId = (int)HttpContext.Current.Session["BestelId"];
            basket.BestelCode = GetBestelcode(basket.BestellingId);
            
            kaartje.BestellingId = (int)HttpContext.Current.Session["BestelId"];
            AddKaartje(kaartje);
            basket.Kaartjes.Add(kaartje);

            return basket;
        }


        public void AddKaartje(Kaartje kaartje)
        {
            using (HaarlemFilmDBContext db = new HaarlemFilmDBContext())
            {
                // kaartje.TotaalPrijs = kaartje.Aantal * kaartje.Evenement.Prijs;
                db.Kaartjes.Add(kaartje);
                db.SaveChanges();
            }
        }

        public Kaartje GetKaartje(int bestellingId)
        {
            Kaartje kaartje;

            using (HaarlemFilmDBContext db = new HaarlemFilmDBContext())
            {
                
                kaartje = db.Kaartjes.Where(krt => krt.BestellingId == bestellingId).FirstOrDefault();
            }
            return kaartje;
        }

        public int AddKlant()
        {
            Klant klant = new Klant();
            using (HaarlemFilmDBContext db = new HaarlemFilmDBContext())
            {
                klant = db.Klants.Add(klant);
                // executes the commands to implement the changes to the database
                db.SaveChanges();
            }
            return klant.KlantId;
        }

        public void EditKaartje(Bestelling basket)
        {
            throw new NotImplementedException();
        }

        public Bestelling GetAllBestellingInfo(int? bestellingId)
        {
            Bestelling bestelling;
            
            using (HaarlemFilmDBContext db = new HaarlemFilmDBContext())
            {
                if (bestellingId != 0 && bestellingId != null)
                {
                    // Bestelling adden maar ook kaartjes moeten apart....
                    bestelling = db.Bestelling.Where(best => best.BestellingId == bestellingId).SingleOrDefault();
                    //bestelling = db.Bestelling.Any(best => best.BestellingId == bestellingId).SingleOrDefault(;
                    bestelling.Kaartjes = (List<Kaartje>)GetAllKaartjes((int)bestellingId);
                }
                else
                {
                    bestelling = new Bestelling();
                    bestelling.BestellingId = 0;
                }

            }
            return bestelling;
        }

        public IEnumerable<Kaartje> GetAllKaartjes(int bestellingId)
        {
            IEnumerable<Kaartje> kaartjes;

            using (HaarlemFilmDBContext db = new HaarlemFilmDBContext())
            {
                kaartjes = db.Kaartjes.Include("Evenement").Where(kaart => kaart.BestellingId == bestellingId).ToList();
            }

            return kaartjes;
        }

        public Evenement GetEvenement(Evenement evenement)
        {
            string evenementChild = evenement.GetType().Name;

            using (HaarlemFilmDBContext db = new HaarlemFilmDBContext())
            {
                if (evenementChild == "Restaurant")
                {
                    evenement = db.Restaurants.Where(evn => evn.EvenementId == evenement.EvenementId).SingleOrDefault();
                }
                else if (evenementChild == "Wandeling")
                {
                    evenement = db.Wandelings.Where(evn => evn.EvenementId == evenement.EvenementId).SingleOrDefault();
                }
                else if(evenementChild == "Concert")
                {
                    evenement = db.Concerts.Where(evn => evn.EvenementId == evenement.EvenementId).SingleOrDefault();
                }
            }

            return evenement;
        }


        public void RemoveBestelling(Bestelling basket)
        {
            throw new NotImplementedException();
        }

        public void RemoveKaartje(Bestelling basket)
        {
            throw new NotImplementedException();
        }

        public int GetBestelIdByCode(string bestelcode)
        {
            int bestelId;

            using (HaarlemFilmDBContext db = new HaarlemFilmDBContext())
            {
                if (db.Bestelling.Any(bestelid => bestelid.BestelCode == bestelcode)) {
                    Bestelling bestelling = db.Bestelling.Where(bestel => bestel.BestelCode == bestelcode).SingleOrDefault();
                    bestelId = bestelling.BestellingId;
                }
                else
                {
                    bestelId = 0;
                }
            }

            return bestelId;
        }

        // GetBestelcode, nieuwe bestelling.
        public string GetBestelcode()
        {
            // Maximaal 1000 keer loopen om bestelcode te maken, anders bestaat bestelcode mogelijk al.
            // Implementeer dan ander systeem. 
            const int MAX_KANSEN = 1000;
            string bestelcode;
            int teller = 0;

            do
            {
                bestelcode = CreateBestelcode();
                teller++;

                if (teller > MAX_KANSEN)
                    return "BESTELCODE_NIET_BESCHIKBAAR";
            }
            while (BestelcodeExists(bestelcode));

            return bestelcode; 
        }

        // GetBestelcode(int bestellingId) bestaande bestelling
        public string GetBestelcode(int bestellingId)
        {
            string bestelcode;

            using (HaarlemFilmDBContext db = new HaarlemFilmDBContext())
            {
                Bestelling bestelling = db.Bestelling.Where(bestel => bestel.BestellingId == bestellingId).SingleOrDefault();
                bestelcode = bestelling.BestelCode;
            }

            return bestelcode;
        }

        public string CreateBestelcode()
        {
            Random r = new Random();
            string tekenRegel = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string bestelcode = "";

            for (int i = 0; i < 6; i++)
            {
                int teken = r.Next(36);
                bestelcode += tekenRegel[teken];
            }

            return bestelcode;
        }

        public bool BestelcodeExists(string bestelcode)
        {
            bool bestelcodeExists = false;

            using (HaarlemFilmDBContext db = new HaarlemFilmDBContext())
            {
                bestelcodeExists = db.Bestelling.Where(bestel => bestel.BestelCode == bestelcode).Any();
            }

            return bestelcodeExists;
        }
    }
}