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
    public class WandelingsController : Controller
    {
        private IWandelingRepository wandelingRepos = new WandelingRepository();
        // GET: Wandelings
        public ActionResult Index()
        {
            return View(wandelingRepos.GetAllWandelings());
        }
        public ActionResult Details()
        {
            return View(wandelingRepos.GetAllWandelings());
        }
        [HttpGet]
        public ActionResult Details(int? evenementId)
        {
            // Controleer of er een geldige invoer is van EvenementId.
            if (evenementId != null)
            {
                return View(wandelingRepos.GetWandeling(evenementId));
            }
            return View("Details");
        }
        [HttpGet]
        public ActionResult BookTour(int? evenementId)
        {
            // Controleer of er een geldige invoer is van EvenementId.
            if (evenementId != null)
            {
                return View(wandelingRepos.GetWandeling(evenementId));
            }
            return View("BookTour");
        }
    }
}
