using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using MvcCoreTest.Entities;

namespace MvcCoreTest.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant Get(int id);
        void Add(Restaurant restaurant);
    }
    public class InMemoryRestaurantData : IRestaurantData
    {
        static InMemoryRestaurantData()
        {
            _restaurants = new ConcurrentBag<Restaurant>
            {
                new Restaurant {Id = 1, Name = "Pete's"},
                new Restaurant {Id = 2, Name = "Bob's"},
                new Restaurant {Id = 3, Name = "Dan's"}
            };
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants;
        }

        public Restaurant Get(int id)
        {
            return _restaurants.FirstOrDefault(r => r.Id == id);
        }

        public void Add(Restaurant restaurant)
        {
            restaurant.Id = _restaurants.Max(r => r.Id) + 1;
        }

        static readonly ConcurrentBag<Restaurant> _restaurants;
    }
}