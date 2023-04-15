using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(x=>x.CommentContent).NotEmpty().WithMessage("İçerik kısmını boş geçemezsiniz");
            RuleFor(x=>x.Subject).NotEmpty().WithMessage("Konu kısmını boş geçemezsiniz");
            RuleFor(x => x.CommentContent).MinimumLength(5).WithMessage("Lütfen en az 5 karakter girişi Yapın");
            RuleFor(x => x.Subject).MaximumLength(20).WithMessage("Çok Fazla karakter girişi yaptınız");
        }
    }
}
