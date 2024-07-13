using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
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
	/*[Authorize] 2-)buraya yazarsak controllerdeki tüm Actionlara girmek için Authorize gerçekleştirmesi lazım
	ancak her sayfaya teker teker [Authorize] yazmak yerine program.cs dosyasındaki yazdığımız kod bloğu
	 [AllowAnonymous] olan sayfalar hariç her sayfayı [Authorize] yapar. */
	public class WriterController : Controller
	{
		/*1-)Otantike olmadığımız sürece /Writer/Index/ sayfasına giremeyiz 
		[Authorize] tek bir action fonksiyonuna yazarsak sodece o actionun viewi için authorization gereklidir.*/

		WriterManager wm = new WriterManager(new EfWriterRepository());

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult WriterProfile()
		{
			return View();
		}

		public IActionResult WriterMail()
		{
			return View();
		}
		[AllowAnonymous]
		public IActionResult Test()
		{
			return View();
		}

		[AllowAnonymous]
		public PartialViewResult WriterNavbarPartial()
		{
			return PartialView();
		}

		[AllowAnonymous]
		public PartialViewResult WriterFooterPartial()
		{
			return PartialView();
		}



		[AllowAnonymous]
		[HttpGet]
		public IActionResult WriterEditProfile()
		{
			var writervalues = wm.TGetById(1);
			return View(writervalues);
		}


		[AllowAnonymous]
		[HttpPost]
		public IActionResult WriterEditProfile(Writer p)
		{
			WriterValidator wl = new WriterValidator();
			ValidationResult results = wl.Validate(p);
			if (results.IsValid)
			{
				wm.TUpdate(p);
				return RedirectToAction("Index", "DashBoard");
			}
			else
			{
				foreach (var item in results.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
				return View();
			}

		}

        [AllowAnonymous]
        [HttpGet]
		public IActionResult WriterAdd()
		{
			return View();
		}

        [AllowAnonymous]
		[HttpPost]
		public IActionResult WriterAdd(AddProfileImage  p)
		{
			Writer w= new Writer();
			//yazar eklerken bilgisayardan fotoğraf yüklemeye yarar
			if(p.WriterImage != null)
			{
				var extension =Path.GetExtension(p.WriterImage.FileName);
				var newimagename = Guid.NewGuid() + extension;
				var location =Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/",newimagename);
				var stream = new FileStream(location,FileMode.Create);
				p.WriterImage.CopyTo(stream);
				w.WriterImage = newimagename;
			}
			w.WriterMail =p.WriterMail;
			w.WriterName =p.WriterName;	
			w.WriterPassword =p.WriterPassword;
			w.WriterStatus =p.WriterStatus;
			w.WriterAbout =p.WriterAbout;	
			wm.TAdd(w);
			return RedirectToAction("Index", "Dashboard");
		}

	}
}