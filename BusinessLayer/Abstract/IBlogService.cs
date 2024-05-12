using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IBlogService
	{
		void BlogAdd(Blog blog);
		void BlogDelete(Blog blog);
		void BlogUpdate(Blog blog);
		List<Blog> GetList();
		Blog GetByID(int id);

		//part 3
		//birbiriyle bağlantısı mig'i olan tabloların özellikleri bir
		//viewde kullanmak
		//Blog entitiesin içine category entities'i dahil ettik
		//böylece blog'un viewinde bi category tablosunun sutunlarını kullanabilicez
		//part4 busines BlogManagerde	
		List<Blog> GetBlogListWithCategory();



		//BlogReadAll sayfasında yazarın diğer bloglarını listelemek için kullanılır.
		List<Blog> GetBlocklistByWriter(int id);



	}
}
