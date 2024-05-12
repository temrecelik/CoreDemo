using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Katman Yapısı(N Tier Arc.)
-Entity Layer:Projede bulunan tablolar ve bu tabloların içerisinde bulunan sütünlar yer alır.Bu tablolar bu katmanda projede bulunan tablolar birer class olarak tutulurlar.
-Data Access layer:Verilere erişim fonksiyonlarının yazıldığı katmandır.(Bunlar create-read-Update-Delete) işlemleridir.
-Business Layer:Validasyon işlemlerinin yani iş kodlarının yazıldığı katmandır.
-Presentation Layer:UI işlemlerinin yapıldığı katmandır.Arayüz işlemlerinin yapıldığı kısımdır.
-Core layer
-API 

Entities Katmanındaki tablolar
-Makale -blog
-Kategori -Category
-Yorumlar
-Yazarlar
-Hakkında
-İletişim
-Adres
*/
 
 namespace EntityLayer.Concrete
{
	public class Category
	{
		[Key]
		public int CategoryId { get; set; }	
		
		public string CategoryName { get; set; }
		
		public string CategoryDescription { get; set; }
        
		public bool CategoryStatus { get; set; }


		//Category ile blog arasında ilişki kurma part1
		 public List<Blog> Blog {  get; set; }	
			


    }
}
 
 
 
 
 


