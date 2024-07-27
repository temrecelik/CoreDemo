using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
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


        public IActionResult Index(int page = 1 )
        {
            var values = cm.GetList().ToPagedList(page,10);
            return View(values);
        }
    }
}
