using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class EvenementModelView
    {
        public Kaartje Kaartje { get; set; }
        public Restaurant Restaurant { get; set; }
        public Concert Concert { get; set; }
        public Wandeling Wandeling { get; set; }
    }
}