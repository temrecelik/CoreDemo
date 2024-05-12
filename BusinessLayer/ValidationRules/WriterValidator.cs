using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
-Fluent Validation İşlemi:Veri tabanına bir kişiyi kaydeterken girdiği bilgilerin 
 doğruluğun sağlamak için uygulanan yöntemlerdir.BusinessLayer'da nuget Managerden 
 FluentValidation ve FluentValidation Asp.NetCore eklentisini kurduk
-Validation işlemlerini UI katmanındada kullanmak için aynı eklentileri UI katmanında da 
 kurduk

 Bu classın adı WriterValidator yani kullanıcılar blog yazarları kayıt olurken buradaki classta
 yazan kurallara göre bilgileri doğrulanarak kayıt olurlar.Bu classı register controllerinde
 bu classtan bir adet nesne üreterek kullanırız.


 */
namespace BusinessLayer.ValidationRules
{
	public class WriterValidator : AbstractValidator<Writer> {

        public WriterValidator()
        {
           
        RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı soyadı kısmı boş geçilemez");
        RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail adresi boş geçilemez");
        RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre Boş geçilemez");

        RuleFor(x => x.WriterName).MinimumLength(5).WithMessage("Lütfen en az 5 karakter girişi yapınız");
        RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter giriniz");
		}
    }	
}
