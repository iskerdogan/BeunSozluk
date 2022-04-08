using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adını boş geçemezsiniz!");
            RuleFor(x => x.WriterName).MinimumLength(3).WithMessage("Yazar adı en az 3 karakterden oluşmalı!");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Yazar adı en fazla 20 karakterden oluşmalı!");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar Soyadını boş geçemezsiniz!");
            RuleFor(x => x.WriterSurname).MinimumLength(3).WithMessage("Yazar Soyadı en az 3 karakterden oluşmalı!");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("Yazar Soyadı en fazla 20 karakterden oluşmalı!");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Yazar Ünvanını boş geçemezsiniz!");
            RuleFor(x => x.WriterTitle).MinimumLength(3).WithMessage("Yazar Ünvanı en az 3 karakterden oluşmalı!");
            RuleFor(x => x.WriterTitle).MaximumLength(50).WithMessage("Yazar Ünvanı en fazla 20 karakterden oluşmalı!");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkımda kısmını boş geçemezsiniz!");
        }
    }
}
