using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class ConcertRepository : IConcertRepository
    {
        public void AddConcert(Concert concert)
        {
            using (HaarlemFilmDBContext db = new HaarlemFilmDBContext())
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
            IEnumerable<Concert> concerts;

            using (HaarlemFilmDBContext db = new HaarlemFilmDBContext())
            {
                concerts = db.Concerts.ToList();
            }

            return concerts;
        }

        public Concert GetConcert(int? evenementId)
        {
            Concert concert;

            using (HaarlemFilmDBContext db = new HaarlemFilmDBContext())
            {
                concert = db.Concerts.Where(conc => conc.EvenementId == evenementId).SingleOrDefault();
            }

            return concert;
        }

        public IEnumerable<Concert> GetConcertsByDay(int? day)
        {
            IEnumerable<Concert> concerts;
            using (HaarlemFilmDBContext db = new HaarlemFilmDBContext())
            {
                concerts = db.Concerts.Where(conc => (int?)conc.Dag == day).ToList();
            }
            return concerts;
        }

        public void RemoveConcert(int? evenementId)
        {
            throw new NotImplementedException();
        }
    }
}