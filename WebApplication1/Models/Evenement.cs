using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace WebApplication1.Models
{
    public abstract class Evenement
    {
        [Key]
        public int EvenementId { get; set; }

        public int Duur { get; set; }
        public int BeginTijd { get; set; }
        public Dag Dag { get; set; }
        public string NaamEvenement { get; set; }
        public int MaxPlaatsen { get; set; }
        public float Prijs { get; set; }
        public string Locatie { get; set; }
        public string ImageUrl { get; set; }

        [NotMapped]
        public string Datum { get { return (((int)Dag + 25 < 31) ? Dag.ToString() + ", " + (25 + (int)Dag).ToString() + "-07-2018" : Dag.ToString());  } }
        [NotMapped]
        public string BeginTijdString { get { return (BeginTijd.ToString()).Insert(2, ":"); } }


        public Evenement()
        { 

        }
    }
}