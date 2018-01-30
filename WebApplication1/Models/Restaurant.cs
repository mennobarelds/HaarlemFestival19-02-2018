using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("Restaurants")]
    public class Restaurant : Evenement
    {
        public int Sterren { get; set; }
        public string SoortKeuken { get; set; }
        public int Sessies { get; set; }

        public Restaurant()
        {

        }
    }
}