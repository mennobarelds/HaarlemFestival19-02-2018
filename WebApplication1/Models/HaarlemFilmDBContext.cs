using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    public class HaarlemFilmDBContext : DbContext
    {
        public HaarlemFilmDBContext() : base("name=HFDBConnection")
        {

        }

        public virtual DbSet<Evenement> Evenements { get; set; }
        // public DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<Wandeling> Wandelings { get; set; }
        public virtual DbSet<Concert> Concerts { get; set; }

        public virtual DbSet<Medewerker> Medewerkers { get; set; }
        public virtual DbSet<Kaartje> Kaartjes { get; set; }
        public virtual DbSet<Klant> Klants { get; set; }
        public virtual DbSet<Begeleider> Begeleiders { get; set; }
        public virtual DbSet<Bestelling> Bestelling { get; set; }
    }
}