using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace WebApplication1.Models
{
    public class Bestelling
    {

        public Bestelling() 
        {

        }

        [Key]
        public virtual int BestellingId { get; set; }
        public virtual bool Betaald { get; set; }
        public virtual string BestelCode { get; set; }
        public virtual float TotaalPrijs { get; set; }

        public virtual ICollection<Kaartje> Kaartjes { get; set; }

        [ForeignKey("Klant")]
        public int KlantId { get; set; }
        public Klant Klant { get; set; }
    }
}