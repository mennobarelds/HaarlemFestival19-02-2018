
namespace WebApplication1.Models
{
    public class Begeleider
    {
        public virtual int BegeleiderId { get; set; }
        public virtual string Naam { get; set; }
        public virtual string Taal { get; set; }

        public Begeleider()
        {

        }
    }
}