using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;

namespace WebApplication1.Models
{
    public class Bestelling
    {

        public Bestelling() 
        {

        }

        public virtual int BestellingId { get; set; }
        public virtual bool Betaald { get; set; }
        public virtual string BestelCode { get; set; }
        public virtual float TotaalPrijs { get; set; }
        public virtual ICollection<Kaartje> Kaartjes { get; set; }
    }
}