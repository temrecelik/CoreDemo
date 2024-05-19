using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IBlogService :IGenericService<Blog>
	{
	
		//buradali fonksiyonlar IGenericService dışında IBlogService için özel yazdığımız fonkisyonlar Eğer bir entity için 
		//delete-ınsert-update-list dışında daha özel iş fonksiyonları yazmak istersek kendi kendi özel ınterfacesine yazarız.

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
