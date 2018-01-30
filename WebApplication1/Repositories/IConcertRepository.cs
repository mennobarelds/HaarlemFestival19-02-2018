using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IConcertRepository
    {
        void AddConcert(Concert concert);
        Concert GetConcert(int? evenementId);
        IEnumerable<Concert> GetAllConcerts();
        IEnumerable<Concert> GetConcertsByDay(int? day);
        void RemoveConcert(int? evenementId);
        void EditConcert(int? evenementId);
    }
}