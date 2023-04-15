using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Kitap adını boş geçemezsiniz");
            RuleFor(x => x.ProductImage).NotEmpty().WithMessage("Kitap resminin url'sini");
            RuleFor(x => x.ProductDescription).NotEmpty().WithMessage("Kitabın konusundan kısaca bahsediniz");
            RuleFor(x => x.Language).NotEmpty().WithMessage("Kitabın dilini giriniz");
            RuleFor(x => x.NoOfPage).NotNull().WithMessage("Kitabın sayfa sayısını giriniz");
            RuleFor(x => x.PublishingDate).Must(x => x.Year <= DateTime.Now.Year).WithMessage("İleri bir tarih giremezsiniz");
        }
    }
}