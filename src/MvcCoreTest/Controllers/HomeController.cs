using Microsoft.AspNetCore.Mvc;
using MvcCoreTest.Models;

namespace MvcCoreTest.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //this.HttpContext.
            //this.File()
            //return Content("Hello, from a controller!");

            var model = new Restaurant {Id = 1, Name = "Bailey's"};
            // The result automatically serializes
            // to JSON!
            return new ObjectResult(model);
        }
    }
}