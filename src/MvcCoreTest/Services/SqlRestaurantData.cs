using System.Collections.Generic;
using System.Linq;
using MvcCoreTest.Entities;

namespace MvcCoreTest.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        private OdeToFoodDbContext _ctx;

        public SqlRestaurantData( OdeToFoodDbContext ctx)
        {
            _ctx = ctx;
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return _ctx.Restaurants;
        }

        public Restaurant Get(int id)
        {
            return _ctx.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public void Add(Restaurant restaurant)
        {
            _ctx.Add(restaurant);
            _ctx.SaveChanges();
        }
    }
}