using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("Restaurants")]
    public class Restaurant : Evenement
    {
        public virtual int Sterren { get; set; }
        public virtual string SoortKeuken { get; set; }
        public virtual int Sessies { get; set; }

        public Restaurant()
        {

        }
    }
}