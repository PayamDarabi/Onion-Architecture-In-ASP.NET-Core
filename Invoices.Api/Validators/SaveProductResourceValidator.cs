using FluentValidation;
using Invoices.Api.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoices.Api.Validators
{
    public class SaveProductResourceValidator : AbstractValidator<SaveProductResource>
    {
        public SaveProductResourceValidator()
        {
            RuleFor(a => a.Title)
                .NotEmpty()
                .WithMessage("عنوان محصول طولانی تر از حد مجاز است.")
                .MaximumLength(250);

            RuleFor(a => a.Price)
               .NotEmpty()
               .WithMessage("مبلغ نمی‌تواند 0 یا کوچیکتر از آن باشد.")
               .GreaterThanOrEqualTo(0);
        }
    }
}
