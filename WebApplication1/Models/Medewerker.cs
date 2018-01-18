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
        public virtual int MedewerkerId { get; set; }
        public virtual string Naam { get; set; }
        public virtual string GebruikersNaam { get; set; }
        public virtual string Wachtwoord { get; set; }

        public Medewerker()
        {

        }
    }
}