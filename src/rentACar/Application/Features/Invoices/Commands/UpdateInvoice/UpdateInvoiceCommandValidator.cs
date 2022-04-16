using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Invoices.Commands.UpdateInvoice
{
    public class UpdateInvoiceCommandValidator : AbstractValidator<UpdateInvoiceCommand>
    {
        public UpdateInvoiceCommandValidator()
        {
            RuleFor(i => i.InvoiceNo).NotEmpty();
            RuleFor(i => i.InvoiceNo).MaximumLength(50);
            RuleFor(i => i.CreatedDate).NotEmpty();
            RuleFor(i => i.RentalStartDate).NotEmpty();
            RuleFor(i => i.RentalEndDate).NotEmpty();
            RuleFor(i => i.RentalDayCount).NotEmpty();
            RuleFor(i => i.TotalRentalPrice).NotEmpty();
            RuleFor(i => i.CustomerId).NotEmpty();
        }
    }
}
