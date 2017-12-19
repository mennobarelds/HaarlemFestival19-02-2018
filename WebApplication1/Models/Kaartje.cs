using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace WebApplication1.Models
{
    public class Kaartje
    {
        [Key]
        public virtual int KaartjeId { get; set; }
        public virtual float TotaalPrijs { get; set; }
        public virtual int Aantal { get; set; }
        public virtual string BijzonderhedenRestaurant { get; set; }
        public virtual int SoortKaartje { get; set; }

        public Kaartje()
        {

        }

        //[ForeignKey("Evenements")]
        public virtual int EvenementId { get; set; }
        public virtual Evenement Evenement { get; set; }
    }
}