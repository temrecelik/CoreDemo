using BusinessLayer.Abstract;
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


        public void BlogAdd(Blog blog)
		{
			throw new NotImplementedException();
		}

		public void BlogDelete(Blog blog)
		{
			throw new NotImplementedException();
		}

		public void BlogUpdate(Blog blog)
		{
			throw new NotImplementedException();
		}

		//part4 
		//artık blog için yazılan viewde category tablosundaki sutunlara
		//erişebiliriz.
		public List<Blog> GetBlogListWithCategory()
		{
			return _blogDal.GetListWithCategory();
		}

		public Blog GetByID(int id)
		{
			throw new NotImplementedException();
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


		//blogları yazarın idsine göre listelebileceğiz
		public List<Blog> GetBlocklistByWriter(int id)
		{
			return _blogDal.GetListAll(x=>x.WriterID == id);
		}
	}
}
