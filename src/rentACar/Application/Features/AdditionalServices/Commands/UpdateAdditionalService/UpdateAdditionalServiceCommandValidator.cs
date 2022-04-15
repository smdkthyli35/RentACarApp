using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AdditionalServices.Commands.UpdateAdditionalService
{
    public class UpdateAdditionalServiceCommandValidator : AbstractValidator<UpdateAdditionalServiceCommand>
    {
        public UpdateAdditionalServiceCommandValidator()
        {
            RuleFor(a => a.Name).NotEmpty();
            RuleFor(a => a.Name).MaximumLength(100);
        }
    }
}
