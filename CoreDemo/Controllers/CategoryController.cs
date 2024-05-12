using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	public class CategoryController : Controller
	{
		//cm ile methodlara erişebiliriz.
		CategoryManager cm = new CategoryManager(new EfCategoryRepository());

		public IActionResult Index()
		{
			var values = cm.GetList(); //cm.Getlist
			return View(values);
		}
	}
}
