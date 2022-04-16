using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CorporateCustomers.Commands.CreateCorporateCustomer
{
    public class CreateCorporateCustomerCommandValidator : AbstractValidator<CorporateCustomer>
    {
        public CreateCorporateCustomerCommandValidator()
        {
            RuleFor(c => c.Email).NotEmpty();
            RuleFor(c => c.Email).MaximumLength(100);
            RuleFor(c => c.CompanyName).NotEmpty();
            RuleFor(c => c.CompanyName).MaximumLength(100);
            RuleFor(c => c.TaxNumber).NotEmpty();
            RuleFor(c => c.TaxNumber).MaximumLength(50);
        }
    }
}
