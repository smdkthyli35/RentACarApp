using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.IndividualCustomers.Commands.UpdateIndividualCustomer
{
    public class UpdateIndividualCustomerValidator : AbstractValidator<IndividualCustomer>
    {
        public UpdateIndividualCustomerValidator()
        {
            RuleFor(i => i.Id).NotEmpty().NotNull();
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
