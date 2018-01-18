using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class ConcertRepository : IConcertRepository
    {
        private HaarlemFilmDBContext db = new HaarlemFilmDBContext();

        public void AddConcert(Concert concert)
        {
            using (db)
            {
                db.Concerts.Add(concert);
                db.SaveChanges();
            }
        }

        public void EditConcert(int? evenementId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Concert> GetAllConcerts()
        {
            var concerts = db.Concerts;
            return (IEnumerable<Concert>)concerts;
        }

        public Concert GetConcert(int? evenementId)
        {
            var evenement = from s in db.Concerts where s.EvenementId.Equals(evenementId) select s;
            return (Concert)evenement;
        }

        public void RemoveConcert(int? evenementId)
        {
            throw new NotImplementedException();
        }
    }
}