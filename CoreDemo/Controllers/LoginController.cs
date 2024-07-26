using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CoreDemo.Controllers
{   /*
 	 Kullanıcının giriş yapmadan görebileceği contact about blog gibi sayfalar [AllowAnonymous] ile açılmalıdır.
	 ama mesaj gönder gibi seçenekler için otontaki olmak gerekliir.
 	 */

    public class LoginController : Controller
	{
		[AllowAnonymous] //Login/Index sayfasına bu kod ile outharization yapmadan girebiliriz

		public IActionResult Index()
		{
			return View();
		}


		[HttpPost]	//Login sayfası için kullanıcı mail ve şifre gönderir. aşağıdaki fonksiyon ile veri tabanı ile karşılaştırılır
		[AllowAnonymous] //Login için kullanıcı giriş yapmak zorunda değil bu nedenle bu sayfa Authorizationdan önce görüntülenebilir.
       
		public async  Task<IActionResult> Index(Writer p)
        {
			Context c = new Context();	
			var datavalue = c.Writers.FirstOrDefault(x => x.WriterMail ==p.WriterMail && x.WriterPassword ==p.WriterPassword);
			if (datavalue != null)
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name,p.WriterMail)
				};

				var useridentity = new ClaimsIdentity(claims,"a");//herhangi bi değer gönderilmeden otantike olunmuyor
				ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
				await HttpContext.SignInAsync(principal);      //Authorization bekleyen sayfaları giriş yaptıktan sonra
                                                                //otomatik olarak [AllowAnonymous] yapmaya yarar

                return RedirectToAction("Index", "Dashboard"); //Yukardaki tüm işlemlerden sonra otontike olabilirsek
															//bizi ilk olarak /Writer/Index sayfasına atayacaktır.
			}
			else
			{
				return View();
			}
			
        }
    }
}





////sisteme giriş yapma fonksiyonu veri tabanındaki writer tablosudaki mail ile password girilen değere eşitlenince giriş yapılır
//			Context c = new Context();	
//			var datavalue = c.Writers.FirstOrDefault(x=>x.WriterMail ==p.WriterMail && x.WriterPassword ==p.WriterPassword);	
           
//			if(datavalue != null)
//			{
//				HttpContext.Session.SetString("username", p.WriterMail);
//				//Giriş yapıldıktan sonra bu sayfaya yönlendirilir.
//				return RedirectToAction("Index","Writer");
//			}
				
//			else
//			{
//				return View();
//			}