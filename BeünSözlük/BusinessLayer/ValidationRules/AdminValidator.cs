using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
        public class AdminValidator : AbstractValidator<Admin>
        {
            public AdminValidator()
            {
                RuleFor(x => x.AdminName).NotEmpty().WithMessage("Admin adını boş geçemezsiniz!");
                RuleFor(x => x.AdminName).MinimumLength(3).WithMessage("Admin adı en az 3 karakterden oluşmalı!");
                RuleFor(x => x.AdminName).MaximumLength(50).WithMessage("Admin adı en fazla 20 karakterden oluşmalı!");
                RuleFor(x => x.AdminSurname).NotEmpty().WithMessage("Admin Soyadını boş geçemezsiniz!");
                RuleFor(x => x.AdminSurname).MinimumLength(3).WithMessage("Admin Soyadı en az 3 karakterden oluşmalı!");
                RuleFor(x => x.AdminSurname).MaximumLength(50).WithMessage("Admin Soyadı en fazla 20 karakterden oluşmalı!");
            }
        }

}
