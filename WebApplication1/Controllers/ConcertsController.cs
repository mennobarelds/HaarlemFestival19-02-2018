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
    public class ConcertsController : Controller
    {
        private ConcertRepository concertRepos = new ConcertRepository();

        // GET: Concerts
        public ActionResult Index()
        {
            //return View(db.Concerts.ToList());
            return View(concertRepos.GetAllConcerts());
        }


    }
}
