﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class CommentManager : ICommentService
	{
		ICommentDal _commentdal;

		public CommentManager(ICommentDal commentdal)
		{
			_commentdal = commentdal;
		}



		public void CommentAdd(Comment comment)
		{
			_commentdal.Insert(comment);
		}

		//bu fonksiyon ile  parametre 10 gidrse id'si 10 olan bloga gönderilen yorumları
		//listelemiş oluruz
		public List<Comment> GetList(int id)
		{
			return _commentdal.GetListAll(x => x.BlogID == id);
		}

		
	}
}
