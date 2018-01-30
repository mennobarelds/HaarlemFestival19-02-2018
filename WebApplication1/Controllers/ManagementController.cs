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
    public class ManagementController : Controller
    {
        private IRestaurantRepository restaurantRep = new RestaurantRepository();
        private IConcertRepository concertRep = new ConcertRepository();
        private IWandelingRepository wandelingRep = new WandelingRepository();

        // GET: Management
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Restaurants()
        {
            IEnumerable<Restaurant> restaurants = restaurantRep.GetAllRestaurants();
            return View(restaurants);
        }

        public ActionResult Concerts()
        {
            return View();
        }

        public ActionResult Wandelings()
        {
            IEnumerable<Wandeling> wandelingen = wandelingRep.GetAllWandelings();
            return View(wandelingen);
        }
    }
}
