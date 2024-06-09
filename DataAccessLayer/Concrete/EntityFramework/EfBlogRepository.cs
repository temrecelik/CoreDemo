using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
	public class EfBlogRepository : GenericRepository<Blog>, IBlogDal
	{
		//part 2
		//birbiriyle bağlantısı mig'i olan tabloların özellikleri bir
		//viewde kullanmak
		//Blog entitiesin içine category entities'i dahil ettik
		//böylece blog'un viewinde bi category tablosunun sutunlarını kullanabilicez
		//part3 busines IBlog Service'de	
		public List<Blog> GetListWithCategory()
		{
			using(var c =new Context())
			{
				return c.Blogs.Include(x =>x.Category).ToList();
			}
		}


		//bu fonksiyon ile yazarların bloglarını listelerken blog tablolarında categoryname yok category id'leri var ancak
		//bu fonksiyon ile ilgili viewda category.categoryname diyerek ilgili blogun category namesine erişebildik
        public List<Blog> GetListWithCategoryByWriter(int id)
        {
            using (var c = new Context())
            {
                return c.Blogs.Include(x => x.Category).Where(x =>x.WriterID == id).ToList();
            } 
        }
    }
}
