using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
/*
 Authorization İşlemleri
-Yetkilendirme işlemleridir.
-Bir kişinin sisteme giriş yapmadan erişemeyeceği sayfalar ve özelliklerdir.
[Authorize] şeklinde attribute ile authorizing işlmeleri yapılır

Bir yazarın websitesinde olacak nitelikleri
	-Profili
	-Mesaj
	-Blogları
	-Giriş Şifreleri
	-Ayarlar 
	
 */


namespace CoreDemo.Controllers
{ 
	//[Authorize] buraya yazarsak tüm Actionlara girmek için Authorize gerçekleştirmesi lazım
	public class WriterController : Controller
	{
		/*Otantike olmadığımız sürece /Writer/Index/ sayfasına giremeyiz */
		[Authorize]
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult WriterProfile()
		{
			return View();
		}

		public IActionResult WriterMail(){ 
			return View();
		}

	}
}
