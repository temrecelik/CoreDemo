using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 Interfacelerin yapısı
-dataacces katmanında  create ,read,delete,update operasyonları ait bir fonksiyon vardır.Bu metotların 
imzası olarak interfaceler kullanılır.Abstract klasörünün üzerinde ınterfaceler tanımlanır.
-Burada yani data access katmanındaki abstract klasöründeki ınterfacelerde  create-delete-update 
fonksiyonlarının imzası bulunur ancak her entities için ayrı ayrı imza atmak yerine bir adet 
generic interface'e T ibaresini kullanarak imza atılır daha sonra bu generic ınterfaceyi
diğer entities adlarını içeren interfaceler miras alır.

 */
namespace DataAccessLayer.Abstract
{

	public interface IBlogDal :IGenericDal<Blog>
	{
		/*
		İmzalar zaten IgeneriDal'da birkez olduğu için ve miras alındığı için ınterface
		içi boş kalır böylece kod tekrarı önlenmiş olur
		*/


		//part1
		//Birbirinen bağımlı tablolardaki özellikleri viewda ortak olarak kullanmak
		//için part ili concrete entiyframwork EfBlogRepository'de
		List<Blog> GetListWithCategory();

	}
}
