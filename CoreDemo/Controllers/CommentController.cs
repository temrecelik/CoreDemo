using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
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

		public PartialViewResult PartialAddComment()
		{
			return PartialView();
		}


		public PartialViewResult CommentListByBlog(int id)
		{
			var values = cm.GetList(id);
			return PartialView(values);
		}
	}
}
