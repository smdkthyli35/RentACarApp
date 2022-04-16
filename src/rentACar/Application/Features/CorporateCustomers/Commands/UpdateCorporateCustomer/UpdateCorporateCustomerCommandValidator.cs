using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CorporateCustomers.Commands.UpdateCorporateCustomer
{
    public class UpdateCorporateCustomerCommandValidator : AbstractValidator<CorporateCustomer>
    {
        public UpdateCorporateCustomerCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty().NotNull();
            RuleFor(c => c.Email).NotEmpty();
            RuleFor(c => c.Email).MaximumLength(100);
            RuleFor(c => c.CompanyName).NotEmpty();
            RuleFor(c => c.CompanyName).MaximumLength(100);
            RuleFor(c => c.TaxNumber).NotEmpty();
            RuleFor(c => c.TaxNumber).MaximumLength(50);
        }
    }
}
