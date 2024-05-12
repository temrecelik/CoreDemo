using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	public class RegisterController : Controller
	{/*Ekleme işlemi yapılırken HttpGet ve HttpPost attributelerinin tanımlandığı metotların
	   isimleri aynı olmak zorundadır.İkiside ekleme komutudur.
		httpget->sayfa yüklenince çalışır
		httppost->buttona basılınca çalışır.
	  *HttpGet attribute'ü sayfada kategorize veya benzeri işler kullanılırken sayfa 
	   yüklendiği anda listelenmesi istenilen niteliklerde kullanılabilir.Örnek 
		kategorilerin listelenmesi, iller ilçelerin gösterilmesi,
	  */
		WriterManager wm = new WriterManager(new EfWriterRepository());


		
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}


		/*Register Controllerden oluşturduğumuz register viewinda html'deki formu writer
		  tablosuna göre doldurduk artık form tetiklendiğinde form'ı açılış tagında post
		  fonksiyonu çalışır bu da controllerdeaki HttpPost'un altındaki IActionResult
		  fonksiyonunu çalıştırır.Aşağıda yazdığımız fonksiyon ile ekleme işlemi biter		  
		 */
		[HttpPost]
		public IActionResult Index(Writer p) 		
		{
			/*register işlemi için busineslayerda validationRules klasöründe WriterValidator
			  classında oluşturduğumuz kuralları register olurkan kullanılması için register
			  controllermızda bir adet WriterValidator classından nesne ürettik*/
			WriterValidator wv = new WriterValidator();
			/*ValidationResult'ı yazarken önce seçmeden yaz sonra ctrl+nokta ile 
			  using Fluent.ValidationResults'ı seç DataAnnotations'u seçersen hata alırsın
			  results değişkeni writer için girilen p değerlerini sağlarsa ekleme işlemi 
			  başarılı olur */
			ValidationResult results = wv.Validate(p);

			
			if(results.IsValid)
			{
				p.WriterStatus = true;
				p.WriterAbout = "DenemeTest";
				wm.WriterAdd(p);
				return RedirectToAction("Index","Home");
				//ekleme işleminde sonra gidilecek sayfa 1.parametre=view 2.parametre:controller
			}

			else
			{
				foreach(var item in results.Errors)
				{
					//Girilen Bilgilerde yanlış kullanım varsa hata fırlatırılır.
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();
			
		}
	}
}
