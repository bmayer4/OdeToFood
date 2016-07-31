using System.Collections.Generic;
using MvcCoreTest.Entities;

namespace MvcCoreTest.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant Get(int id);
        void Add(Restaurant restaurant);
        int Commit();
    }
}