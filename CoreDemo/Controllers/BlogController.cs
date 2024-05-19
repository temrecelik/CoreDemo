using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{   [AllowAnonymous] //kullanıcı otantike olmadan blog sayfasını görebilir.

    public class BlogController : Controller
    {
      
        //Blog manager'deki kodları kullanabiliriz.
        BlogManager bm = new BlogManager(new EfBlogRepository());

        public IActionResult Index()
        {
            //values degiskeni ile blog tablasuna artık view yani
            //UI tarafında erişip ekrana bastırabilicez
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }
		//bir tablo için birden fazla view yani sayfa oluşturabiliriz.
		//blog controline yazdığımız her IActionResult fonksiyonu ile
		//birer view oluştururuz.


		/*AŞAĞIDAKİ FONKSİYONUNUN NE İŞE YARADIĞI
         
		 *Şuanda blog controller'ı içerisindeyiz yani biz aşağıdaki gibi
          BlogReadAll fonksiyonunu yazdığımızda oluşacak viewin linki
          domainname/blog/BlogReadAll/id 
          yani parametredeki id değeri linkin sonuna yazılır.Açılan sayfa öyle gelir.Bizde
          eğer html kısmında sona sayıyı denk getirirsek bu sayı id olarak alınır
          ve bu fonksiyon bize bm'deki yani blogrepositorydeki GetBlogByID fonksiyonuna
          göre değer döndürür yani aslında biz o idyi verdiğimizde blog tablosundaki idsi 
          o olan nesnenin özelliklerine erişim yapabiliriz. Bu da viewde foreach döngüleri
          ile idye göre dinamik işler yapmamızı sağlar
         */
		
		public IActionResult BlogReadAll(int id) {
            
            ViewBag.i = id; //bu kod satırı ile linkteki id değerini tutarız
            var values = bm.GetBlogByID(id);
            return View(values);
        }

        public IActionResult BlogListByWriter()
        {
            var values = bm.GetBlocklistByWriter(1);
            return View(values);
        }

        [HttpGet]
        public IActionResult BlogAdd()
        {

            return View();
        }

        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {
            BlogValidator  bv = new BlogValidator();      //bu iki kod BlogValidatore göre girilen değerleri kontrol eder
            ValidationResult results = bv.Validate(p);   //using FluentValidation.Result; ı seçerek import et yoksa çalışmıyor


            if (results.IsValid)
            {
                p.BlogStatus = true;
                p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.WriterID = 1;
                bm.TAdd(p);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in results.Errors) //BlogValidator'e göre fırlatılan hatalar
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            
                return View();
        }




    }
}
