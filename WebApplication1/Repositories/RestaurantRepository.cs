using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private HaarlemFilmDBContext db = new HaarlemFilmDBContext();

        public void AddRestaurant(Restaurant restaurant)
        {
            using (db)
            {
                db.Restaurants.Add(restaurant);
                // executes the commands to implement the changes to the database
                db.SaveChanges();
            }
        }

        public void EditRestaurant(int? evenementId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            return db.Restaurants.ToList();
        }

        public Restaurant GetRestaurant(int? evenementId)
        {
            var evenement = from s in db.Restaurants where s.EvenementId.Equals(evenementId) select s;
            return (Restaurant)evenement;
        }

        public void RemoveRestaurant(int? evenementId)
        {
            throw new NotImplementedException();
        }
    }
}