using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class NatificationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
