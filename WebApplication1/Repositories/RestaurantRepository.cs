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
        public void AddRestaurant(Restaurant restaurant)
        {
            using (HaarlemFilmDBContext db = new HaarlemFilmDBContext())
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
            IEnumerable<Restaurant> restaurants;

            using (HaarlemFilmDBContext db = new HaarlemFilmDBContext())
            {
                restaurants = db.Restaurants.ToList();
            }

            return restaurants;
        }

        public Restaurant GetRestaurant(int? evenementId)
        {
            Restaurant restaurant;

            using (HaarlemFilmDBContext db = new HaarlemFilmDBContext())
            {
                restaurant = db.Restaurants.Where(rest => rest.EvenementId == evenementId).SingleOrDefault();
            }
            return restaurant;
        }

        public void RemoveRestaurant(int? evenementId)
        {
            throw new NotImplementedException();
        }
    }
}