using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Sessions
{
    public class BasketSession
    {

        private BasketSession()
        {

        }

        public static void CreateSession()
        {
            HttpContext.Current.Session["AantalKaartjes"] = 0;
        }

        public static void AddTicket()
        {

        }

        public static void SubstractTicket()
        {

        }

        public static void DeleteSession()
        {
            HttpContext.Current.Session.Abandon();
        }
        
    }
}