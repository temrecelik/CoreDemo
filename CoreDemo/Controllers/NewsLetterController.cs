using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	//BlogReadAll sayfasında mail bültenine kaydolmak için bir alan var bu onun controlleri oluşturduğumuz 
	//SubscribeMail view'ı partial viewdır ve bu controllerdaki parametreli fonksiyondan  oluşmuşdur 
	public class NewsLetterController : Controller
	{
		NewsLetterManager nm = new NewsLetterManager(new EfNewsLetterRepository());

		[HttpGet]

		public PartialViewResult SubscribeMail()
		{
			return PartialView();
		}

		[HttpPost]
		public PartialViewResult SubscribeMail(NewsLetter p)
	
		{
			p.MailStatus = true;
			nm.AddNewsLetter(p);

			return PartialView();
		}
	}

}
