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
            return View(basketRepos.GetAllBestellings());
        }

        // GET: Kaartjes/Create
        public ActionResult Create()
        {
            return View();
        }

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
    }
}
