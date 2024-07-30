using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using X.PagedList.Extensions;
//iki tane pagedlist kütüphanesi kurduk böylece web sayfasında fazladan şeyler olunca 2. sayfa olarak gösterecek
//Aşağıda ToPagedList(page,3) fonkisyonu ile kullanılır. View tarafında kütüphaneleri n using dahil edilmesi lazım

namespace CoreDemo.Areas.Admin.Controllers
{
    [AllowAnonymous]

    [Area("Admin")]
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());


        public IActionResult Index(int page = 1)
        {
            var values = cm.GetList().ToPagedList(page, 10);
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category p)
        {
            CategoryValidator cv = new CategoryValidator();
            ValidationResult results = cv.Validate(p);

            if (results.IsValid)
            {
                p.CategoryStatus = true;
                cm.TAdd(p);
                return RedirectToAction("Index", "Category");

            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult CategoryDelete(int id)
        {
            var value = cm.TGetById(id);    
            cm.TDelete(value);
            return RedirectToAction("Index");
        }
    }
}
