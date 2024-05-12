using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
/*
 Dipnot:Refoctoring işlemleri:Projeyi yeniden düzenleme fazlalıkları falan silme işlemidir.
 */
namespace CoreDemo.ViewComponents.Category
{

	public class CategoryList :ViewComponent
	{
		CategoryManager cm = new CategoryManager(new EfCategoryRepository());

		public IViewComponentResult Invoke()
		{
			var values = cm.GetList();
			return View(values);
		}
	}
}
