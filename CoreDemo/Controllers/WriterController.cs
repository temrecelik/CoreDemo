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
	//[Authorize] 2-)buraya yazarsak controllerdeki tüm Actionlara girmek için Authorize gerçekleştirmesi lazım
	public class WriterController : Controller
	{
		/*1-)Otantike olmadığımız sürece /Writer/Index/ sayfasına giremeyiz 
		[Authorize] tek bir action fonksiyonuna yazarsak sodece o actionun viewi için authorization gereklidir.*/
		[AllowAnonymous]
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
