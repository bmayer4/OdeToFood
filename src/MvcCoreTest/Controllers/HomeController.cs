using Microsoft.AspNetCore.Mvc;
using MvcCoreTest.Services;

namespace MvcCoreTest.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;

        public HomeController(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }
        public IActionResult Index()
        {
            //this.HttpContext.
            //this.File()
            //return Content("Hello, from a controller!");

            var model = _restaurantData.GetAll();
            // The result automatically serializes
            // to JSON!
            //return new ObjectResult(model);
            return View(model);
        }
    }
}