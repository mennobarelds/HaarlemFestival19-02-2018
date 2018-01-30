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
        public int BestellingId { get; set; }
        public bool Betaald { get; set; }
        public string BestelCode { get; set; }
        public float TotaalPrijs { get; set; }

        public List<Kaartje> Kaartjes { get; set; }

        [ForeignKey("Klant")]
        public int KlantId { get; set; }
        public Klant Klant { get; set; }
    }
}