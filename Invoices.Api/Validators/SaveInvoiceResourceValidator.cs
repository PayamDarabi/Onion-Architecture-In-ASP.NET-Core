using FluentValidation;
using Invoices.Api.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoices.Api.Validators
{
    public class SaveInvoiceResourceValidator : AbstractValidator<SaveInvoiceResource>
    {
        public SaveInvoiceResourceValidator()
        {
            RuleFor(a => a.BuyerName)
                .NotEmpty()
                .WithMessage("عنوان خریدار طولانی تر از حد مجاز است.")
                .MaximumLength(100);
        }
    }
}
