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
	public class BlogManager : IBlogService
	{
		IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
			_blogDal = blogDal;
        }

	

		//part4 
		//artık blog için yazılan viewde category tablosundaki sutunlara
		//erişebiliriz.
		public List<Blog> GetBlogListWithCategory()
		{
			return _blogDal.GetListWithCategory();
		}

		//Bu idye blog türünde bir veri gönderir.Yani liste göndermez.Silme ve Güncelleme işlemlerinde bu çalışır
		public Blog TGetById(int id)
		{
			return _blogDal.GetByID(id);
		}

		//Bu fonksiyon ile girilen id değerine göre blog çekicez GetById'den farkı list 
		//türünde olması listeleme işlemi yaparken list fonksiyonu ile yapmalıyız
		public List<Blog> GetBlogByID(int id) {

			return _blogDal.GetListAll(X => X.BlogID == id);
		}


		public List<Blog> GetList()
		{
			return _blogDal.GetListAll();
		}

        
		public List<Blog> GetLast3Blog()
        {
			  return _blogDal.GetListAll().TakeLast(3).ToList();
        }

        //blogları yazarın idsine göre listelebileceğiz
        public List<Blog> GetBlocklistByWriter(int id)
		{
			return _blogDal.GetListAll(x=>x.WriterID == id);
		}

        public void TAdd(Blog t)
        {
            _blogDal.Insert(t);
        }

        public void TDelete(Blog t)
        {
            _blogDal.Delete(t);
        }

        public void TUpdate(Blog t)
        {
            _blogDal.Update(t);	
        }


		public List<Blog> GetListWithCategoryByWriterBm(int id) //bir blogun writer id'si var ve category id'si var biz category idsine göre aslında category name'i getirdik
		{
			return _blogDal.GetListWithCategoryByWriter(id);
		}
    }
}
