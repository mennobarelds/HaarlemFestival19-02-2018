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

            if (bestelId != null)
            {
                return View(basketRepos.GetAllBestellingInfo(bestelId));
            }
            else
            {
                return View(basketRepos.GetAllBestellingInfo(23));
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Bestelling bestelling)
        {
            ViewBag.Title = bestelling.BestelCode;
            return View();
        }

        [HttpGet]
        public ActionResult AddKaartje(int evenementId)
        {
            Kaartje kaartje = new Kaartje();
            kaartje.Aantal = 1;
            kaartje.TotaalPrijs = 10;
            kaartje.BijzonderhedenRestaurant = "Rolstoel en allergisch voor pinda's";
            kaartje.SoortKaartje = 2;
            kaartje.DagEvenement = 2;
            kaartje.EvenementId = evenementId;

            Bestelling bestelling = basketRepos.AddBestelling(kaartje);

            return View("Index",bestelling);
        }

        [HttpGet]
        public ActionResult AddKaartje(Evenement evenement)
        {
            Kaartje kaartje = new Kaartje();
            kaartje.Aantal = 1;
            kaartje.TotaalPrijs = 10;
            kaartje.BijzonderhedenRestaurant = "Rolstoel en allergisch voor pinda's";
            kaartje.SoortKaartje = 2;
            kaartje.DagEvenement = 2;
            // kaartje.EvenementId = evenementId;

            Bestelling bestelling = basketRepos.AddBestelling(kaartje);

            return View("Index", bestelling);
        }

    }
}
