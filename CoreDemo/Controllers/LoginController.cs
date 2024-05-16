using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	public class LoginController : Controller
	{
		[AllowAnonymous] //Login/Index sayfasına bu kod ile outharization yapmadan girebiliriz
		public IActionResult Index()
		{
			return View();
		}


		[HttpPost]	//Login sayfası için kullanıcı mail ve şifre gönderir. aşağıdaki fonksiyon ile veri tabanı ile karşılaştırılır
		[AllowAnonymous] //Login için kullanıcı giriş yapmak zorunda değil bu nedenle bu sayfa Authorizationdan önce görüntülenebilir.
        public IActionResult Index(Writer p)
        {
			//sisteme giriş yapma fonksiyonu veri tabanındaki writer tablosudaki mail ile password girilen değere eşitlenince giriş yapılır
			Context c = new Context();	
			var datavalue = c.Writers.FirstOrDefault(x=>x.WriterMail ==p.WriterMail && x.WriterPassword ==p.WriterPassword);	
           
			if(datavalue != null)
			{
				HttpContext.Session.SetString("username", p.WriterMail);
				//Giriş yapıldıktan sonra bu sayfaya yönlendirilir.
				return RedirectToAction("Index","Writer");
			}
				
			else
			{
				return View();
			}
			
        }




    }
}
