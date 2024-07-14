    using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class DashboardController : Controller
    {
        
        public IActionResult Index()
        {
            Context c = new Context();
            var oneWeekAgo = DateTime.Now.AddDays(-7);
            ViewBag.v1 = c.Blogs.Count().ToString(); //Toplam yazılan blog sayısını getirir
            ViewBag.v2 = c.Blogs.Where(x => x.WriterID == 1).Count().ToString();//yazarın yazdığı blog sayısı dinamikleştirilecek
            ViewBag.v3 = c.Blogs.Where(x => x.BlogCreateDate >= oneWeekAgo).Count().ToString(); //son bir haftada yazılan blog sayısı
            return View();
        }
    }
}
    