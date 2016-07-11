using System.Collections.Concurrent;
using System.Collections.Generic;
using MvcCoreTest.Models;

namespace MvcCoreTest.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }
    public class InMemoryRestaurantData : IRestaurantData
    {
        public InMemoryRestaurantData()
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

        readonly ConcurrentBag<Restaurant> _restaurants;
    }
}