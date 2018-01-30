using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    public class RestaurantsController : Controller
    {
        private IRestaurantRepository restaurantRepos = new RestaurantRepository();

        // GET: Restaurants
        public ActionResult Index()
        {
            IBasketRepository basketRep = new BasketRepository();

            return View(restaurantRepos.GetAllRestaurants());
        }

        [HttpGet]
        public ActionResult Details(int? evenementId)
        {
            // Controleer of er een geldige invoer is van EvenementId.
            if (evenementId != null) {
                return View(restaurantRepos.GetRestaurant(evenementId));
            }
            return View("Index");
        }




    }
}
