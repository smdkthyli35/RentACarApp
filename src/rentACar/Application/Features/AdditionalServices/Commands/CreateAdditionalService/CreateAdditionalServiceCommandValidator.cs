using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AdditionalServices.Commands.CreateAdditionalService
{
    public class CreateAdditionalServiceCommandValidator : AbstractValidator<CreateAdditionalServiceCommand>
    {
        public CreateAdditionalServiceCommandValidator()
        {
            RuleFor(a => a.Name).NotEmpty();
            RuleFor(a => a.Name).MaximumLength(100);
        }
    }
}
