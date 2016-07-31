using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcCoreTest.Services;

namespace MvcCoreTest.ViewComponents
{
    public class Greeting : ViewComponent
    {
        private IGreeter _greeter;

        public Greeting(IGreeter greeter)
        {
            _greeter = greeter;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await Task.Run(() => _greeter.GetGreeting());
            return View("Default", model);
        }
    }
}