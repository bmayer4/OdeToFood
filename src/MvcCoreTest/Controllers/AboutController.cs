using Microsoft.AspNetCore.Mvc;

namespace MvcCoreTest.Controllers
{
    [Route("[controller]")]
    //[Route("company/[controller]/[action]")]
    public class AboutController
    {
        [Route("")]
        public string Phone()
        {
            return "1-555-555-1212";
        }

        [Route("[action]")]
        public string Country()
        {
            return "USA";
        }

        public string Index()
        {
            return "My Company About Page";
        }
    }
}