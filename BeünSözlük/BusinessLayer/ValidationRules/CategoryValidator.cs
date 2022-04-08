using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x=>x.CategoryName).NotEmpty().WithMessage("Kategori adını boş geçemezsiniz!");
            RuleFor(x=>x.CategoryName).MinimumLength(3).WithMessage("Kategori adı en az 3 karakterden oluşmalı!");
            RuleFor(x=>x.CategoryName).MaximumLength(20).WithMessage("Kategori adı en fazla 20 karakterden oluşmalı!");
            RuleFor(x=>x.CategoryDescription).NotEmpty().WithMessage("Kategori açıklamasını boş geçemezsiniz!");

        }
    }
}
