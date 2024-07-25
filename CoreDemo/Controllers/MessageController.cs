using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {

        Message2Manager mn = new Message2Manager(new EfMessage2Repository());

        public IActionResult InBox()
        {
            int id = 2;
            var values = mn.GetInboxListByWriter(id);
            return View(values);
        }


        [HttpGet]
        public IActionResult MessageDetails(int id)
        {

            var value = mn.TGetById(id);
            return View(value);
        }
    }
}