using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IWandelingRepository
    {
        void AddWandeling(Wandeling wandeling);
        Wandeling GetWandeling(int? evenementId);
        IEnumerable<Wandeling> GetAllWandelings();
    }
}
