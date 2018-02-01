using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("Concerts")]
    public class Concert : Evenement
    {
        public string BandNaam { get; set; }
        public string Zaal { get; set; }

        [NotMapped]
        public string ImageUrlConcert { get { return (Dag.ToString().ToLower() + "/" + ImageUrl); } }

        public Concert()
        {

        }
    }
}