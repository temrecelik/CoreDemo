using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
/*
 Burada yani data access katmanındaki abstract klasöründeki ınterfacelerde  create-delete-update 
fonksiyonlarının imzası bulunur ancak her entities için ayrı ayrı imza atmak yerine bir adet 
generic interface'e T ibaresini kullanarak imza atılır daha sonra bu generic ınterfaceyi
diğer entities adlarını içeren interfaceler miras alır.
----------------------devam olarak bu ınterfaceleri classlar nasıl miras olalarak alacak onu yaz

 */	

	

	public interface IGenericDal<T> where T : class
	{
		//imzaları sadece IgenericDal'da bir kez aşağıdaki gibi generic yani T kullanarak yazdık
		//diğer interfaceler bu ınterfaceyi miras alır generic kısma yani T yerine ilgili olduğu
		//entities'in adı yazılır.
		void Insert(T t);
		void Delete(T t);
		void Update(T t);
		List<T> GetListAll();
		T GetByID(int id);

		List<T> GetListAll(Expression<Func<T, bool>>  filter);



	}
}
