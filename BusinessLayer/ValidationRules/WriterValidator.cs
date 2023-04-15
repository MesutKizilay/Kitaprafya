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
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adını giriniz");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar soyadını giriniz");
            RuleFor(x => x.WriterImage).NotEmpty().WithMessage("Yazar resminin url'sini giriniz");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Yazar hakkında kısa bilgi veriniz");
        }
    }
}