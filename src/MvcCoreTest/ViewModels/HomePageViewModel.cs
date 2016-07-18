using System.Collections.Generic;
using MvcCoreTest.Entities;

namespace MvcCoreTest.ViewModels
{
    public class HomePageViewModel
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public string CurrentGreeting { get; set; }
    }
}