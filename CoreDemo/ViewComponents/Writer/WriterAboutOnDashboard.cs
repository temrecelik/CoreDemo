using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
  

    public class WriterAboutOnDashboard :ViewComponent
    {
         WriterManager wm = new WriterManager(new EfWriterRepository());

        public IViewComponentResult Invoke()
        {
            var UserMail = User.Identity.Name;
            Context c = new Context();  
            var UserId = c.Writers.Where(x => x.WriterMail == UserMail).Select(y => y.WriterId).FirstOrDefault();

            var values = wm.GetWriterById(UserId);
            return View(values);
        }

    }
}
