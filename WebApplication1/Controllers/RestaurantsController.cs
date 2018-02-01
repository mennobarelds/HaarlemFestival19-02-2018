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

        [HttpPost]
        public ActionResult Details(int evenementId, int aantal, int prijs, SoortKaartje soortKaartje, string bijzonderheden, int dag)
        {
            IBasketRepository basketRepos = new BasketRepository();
            Kaartje kaartje = new Kaartje();
            kaartje.Aantal = aantal;
            kaartje.DagEvenement = dag;
            kaartje.TotaalPrijs = prijs * aantal;
            kaartje.BijzonderhedenRestaurant = bijzonderheden;
            kaartje.SoortKaartje = (int)soortKaartje;
            kaartje.DagEvenement = 3;
            kaartje.EvenementId = evenementId;

            Bestelling bestelling = basketRepos.AddBestelling(kaartje);

            return View("Index", restaurantRepos.GetAllRestaurants());
        }


    }
}
