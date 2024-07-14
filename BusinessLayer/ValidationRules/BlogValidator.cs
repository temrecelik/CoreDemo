using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator() {

            /*
             Migration işlemi ile data base tablo çekerken tabloların sütunlarının nullable'ları false olarak ekli
             eğerki input alanına giriş yaparken boş bırakırsak hata o taraftan hatayı buradan fırlatmak için onları
             true yapıp validation işlemlerini burdan yaparız yani notEmpty()'yi görmüyo migrationdaki hata messagını görüyor
             */

            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Lütfen bir blog başlığı griniz.");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Lütfen blog yazısı giriniz.");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Lütfen blog yazınız için uygun bir resim ekleyiniz.");
            RuleFor(x => x.BlogTitle).MaximumLength(100).WithMessage("Lütfen daha kısa bir başlık seçiniz");
			RuleFor(x => x.BlogContent).MinimumLength(30).WithMessage("Blog yazınız en az 30 karakter içermelidir.");

		}
            
    }
}
