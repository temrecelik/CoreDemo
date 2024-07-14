using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Natification
{
    public class NatificationList : ViewComponent
    {
        NatificationManager nm = new NatificationManager(new EfNatificationRepository());

        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
