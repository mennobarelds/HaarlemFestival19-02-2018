using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IRestaurantRepository
    {
        void AddRestaurant(Restaurant restaurant);
        Restaurant GetRestaurant(int? evenementId);
        IEnumerable<Restaurant> GetAllRestaurants();
        void RemoveRestaurant(int? evenementId);
        void EditRestaurant(int? evenementId);
    }
}