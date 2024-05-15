using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	public class AboutController : Controller
	{
		AboutManager am = new AboutManager(new EfAboutRepository());	

		public IActionResult Index()

		{
			var values = am.GetList();
			return View(values);
		}




		//Hakkmızda sayfasının sosyal medya bölümlerini tutan partial view
		public PartialViewResult SocialMediaAbout()
		{
			return PartialView();	
		} 
	}
}
