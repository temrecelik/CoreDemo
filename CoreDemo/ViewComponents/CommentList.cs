/*
 VİEW COMPONENT NEDİR
 Bir view sayfasında ve o view'a ait parçalı viewlerde birden fazla model kullanılamaz.
 Yani model olarak birtane Entity kullanabiliriz.Birden fazla entitinin sütünlarına aynı 
 viewde ulaşmak için  ya business katmanında özel iş fonksiyonları yazarız ya da UI(MVV) 
 projesinde ViewComponent yapısını kullanırız.

	-Partial viewler url ye direkt erişebilir View component erişemez.
	-ViewComponents adında bir klasör oluşturulur.
	-içinde kullanılacak classlar ViewComponent sınıfından miras alır.
	-başlangıçta ViewComponentler tanımlandığında default.cshtml ismi atanır.
	-Proje çalıştığında componentler 
		views/components/..  ya da views/shared/components/.. 'de aranır.
 */

using CoreDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents
{
	public class CommentList :ViewComponent
	{
		public IViewComponentResult Invoke()
		{
		
			return View();
			

			
		}
	}
}
