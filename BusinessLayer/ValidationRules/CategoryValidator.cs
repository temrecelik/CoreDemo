using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class CategoryValidator :AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(X => X.CategoryName).NotEmpty().WithMessage("Kategori adı boş geçilemez");
            RuleFor(X => X.CategoryDescription).NotEmpty().WithMessage("Kategori adı boş geçilemez");
        }

    }
}
