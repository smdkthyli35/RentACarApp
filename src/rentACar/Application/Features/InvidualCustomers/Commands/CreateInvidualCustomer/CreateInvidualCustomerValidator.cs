using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.InvidualCustomers.Commands.CreateInvidualCustomer
{
    public class CreateInvidualCustomerValidator : AbstractValidator<InvidualCustomer>
    {
        public CreateInvidualCustomerValidator()
        {
            RuleFor(i => i.Email).NotEmpty();
            RuleFor(i => i.Email).MaximumLength(100);
            RuleFor(i => i.FirstName).NotEmpty();
            RuleFor(i => i.FirstName).MaximumLength(50);
            RuleFor(i => i.LastName).NotEmpty();
            RuleFor(i => i.LastName).MaximumLength(50);
            RuleFor(i => i.NationalIdentity).NotEmpty();
            RuleFor(i => i.NationalIdentity).MaximumLength(11);
        }
    }
}
