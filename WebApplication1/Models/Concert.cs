using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("Concerts")]
    public class Concert : Evenement
    {
        public virtual string BandNaam { get; set; }
        public virtual string Zaal { get; set; }

        public Concert()
        {

        }
    }
}