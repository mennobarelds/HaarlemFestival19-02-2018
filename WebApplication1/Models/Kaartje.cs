using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace WebApplication1.Models
{
    public class Kaartje
    {
        [Key]
        public int KaartjeId { get; set; }
        public float TotaalPrijs { get; set; }
        public int Aantal { get; set; }
        public string BijzonderhedenRestaurant { get; set; }
        public int SoortKaartje { get; set; }
        public int DagEvenement { get; set; }

        public Kaartje()
        {

        }


        public int EvenementId { get; set; }
        public Evenement Evenement { get; set; }

        [ForeignKey("Bestelling")]
        public int BestellingId { get; set; }
        public Bestelling Bestelling { get; set; }
    }
}