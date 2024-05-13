using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace CoreDemo.Controllers
{
	public class CommentController : Controller
	{



		/*
		 Controllerde parçalı Iaction result fonksiyonu PartailViewResult ile yazılır.
		 */
		CommentManager cm = new CommentManager (new EfCommentRepository());
		public IActionResult ındex()
		{
			return View();	
		}


		[HttpGet]
		public PartialViewResult PartialAddComment()
		{
			return PartialView();
		}
		[HttpPost]
		public PartialViewResult PartialAddComment(Comment p)
		{
			p.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			p.CommentStatus = true;
			p.BlogID = 30;
			cm.CommentAdd(p);

			return PartialView();
		}


		public PartialViewResult CommentListByBlog(int id)
		{
			var values = cm.GetList(id);
			return PartialView(values);
		}
	}
}
