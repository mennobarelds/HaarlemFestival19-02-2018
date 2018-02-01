using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    public class Medewerker
    {
        [Key]
        public int MedewerkerId { get; set; }
        public string Naam { get; set; }
        public string GebruikersNaam { get; set; }
        public string Wachtwoord { get; set; }

        public Medewerker()
        {

        }
    }
}