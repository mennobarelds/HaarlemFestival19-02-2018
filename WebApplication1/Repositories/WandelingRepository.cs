using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class WandelingRepository : IWandelingRepository
    {
        private HaarlemFilmDBContext db = new HaarlemFilmDBContext();

        public void AddWandeling(Wandeling wandeling)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Wandeling> GetAllWandelings()
        {
            IEnumerable<Wandeling> wandelings;

            using (HaarlemFilmDBContext db = new HaarlemFilmDBContext())
            {
                wandelings = db.Wandelings.Include("Begeleider").OrderBy(m => m.EvenementId).ToList();
            }
            return wandelings;
        }

        public Wandeling GetWandeling(int? evenementId)
        {
            
            throw new NotImplementedException();
        }
    }
}