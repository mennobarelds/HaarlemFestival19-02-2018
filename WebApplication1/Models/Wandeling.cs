using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("Wandelings")]
    public class Wandeling : Evenement
    {

        public int BegeleiderId { get; set; }
        public Begeleider Begeleider { get; set; }

        public Wandeling()
        {

        }
    }
}