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
    public class BasketController : Controller
    {
        private IBasketRepository basketRepos = new BasketRepository();

        // GET: Basket
        public ActionResult Index()
        {
            int? bestelId = (int?)HttpContext.Session["BestelId"];

            if (bestelId != 0)
            {
                return View(basketRepos.GetAllBestellingInfo(bestelId));
            }
            else
            {
                return View(basketRepos.GetAllBestellingInfo(bestelId));
            }
            // return View();
        }

        // GET: Kaartjes/Create
        public ActionResult Create()
        {
            return View();
        }
        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Bestelling bestelling, Kaartje kaartje)
        {
            if (ModelState.IsValid)
            {
                basketRepos.AddBestelling(bestelling, kaartje,false);
                return RedirectToAction("Index");
            }

            return View("Index");
        }
        */

        //GetBestelIdByCode

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Bestelling bestelling)
        {
            ViewBag.Title = bestelling.BestelCode;
            return View();
        }

        [HttpGet]
        public ActionResult AddKaartje()
        {
            return View("Index");
        }

        [HttpPost]
        public ActionResult AddKaartje(int evenementId, int aantal, int prijs, SoortKaartje soortKaartje, string bijzonderheden, Dag dag)
        {
            Kaartje kaartje = new Kaartje();
            kaartje.Aantal = aantal;
            kaartje.DagEvenement = (int)dag;
            kaartje.TotaalPrijs = prijs * aantal;
            kaartje.BijzonderhedenRestaurant = bijzonderheden;
            kaartje.SoortKaartje = (int)soortKaartje;
            kaartje.DagEvenement = 3;
            kaartje.EvenementId = evenementId;

            Bestelling bestelling = basketRepos.AddBestelling(kaartje);

            return View("Index", bestelling);
        }

        [HttpGet]
        public ActionResult GetOrder()
        {

            return View("Index");
        }

        [HttpPost]
        public ActionResult GetOrder(Bestelling bestelling)
        {
            string ordercode = bestelling.BestelCode;
            HttpContext.Session["BestelCode"] = ordercode;

            int bestelId = basketRepos.GetBestelIdByCode(ordercode);

            if (bestelId == 0)
            {
                HttpContext.Session["BestelId"] = 0;
                return View("GetOrder");
            }
            else
            {
                HttpContext.Session["BestelId"] = bestelId;
                return View("GetOrder");
            }
            return View("Index");
        }

    }
}
