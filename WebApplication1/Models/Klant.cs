using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Klant
    {
        [Key]
        public int KlantId { get; set; }

        public Klant()
        {

        }
    }
}