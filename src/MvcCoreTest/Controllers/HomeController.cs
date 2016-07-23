using Microsoft.AspNetCore.Mvc;
using MvcCoreTest.Entities;
using MvcCoreTest.Services;
using MvcCoreTest.ViewModels;

namespace MvcCoreTest.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;
        private IGreeter _greeter;

        public HomeController(IRestaurantData restaurantData, IGreeter greeter)
        {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }
        public IActionResult Index()
        {
            //this.HttpContext.
            //this.File()
            //return Content("Hello, from a controller!");

            var model = new HomePageViewModel();
            model.Restaurants = _restaurantData.GetAll();
            model.CurrentGreeting = _greeter.GetGreeting();
            
            // The result automatically serializes
            // to JSON!
            //return new ObjectResult(model);
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var restaurant = _restaurantData.Get(id);

            if (restaurant == null)
            {
                return RedirectToAction("Index");
            }

            return View(restaurant);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RestaurantEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var r = new Restaurant();
            r.Name = model.Name;
            r.Cuisine = model.Cuisine;

            _restaurantData.Add(r);

            return RedirectToAction("Details", new {id = r.Id});
        }
    }
}