using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace WebApplication1.Models
{
    public abstract class Evenement
    {
        [Key]
        public int EvenementId { get; set; }

        public virtual int Duur { get; set; }
        public virtual int BeginTijd { get; set; }
        public virtual int Dag { get; set; }
        public virtual string NaamEvenement { get; set; }
        public virtual int MaxPlaatsen { get; set; }
        public virtual float Prijs { get; set; }
        public virtual string Locatie { get; set; }

        public Evenement()
        { 

        }
    }
}