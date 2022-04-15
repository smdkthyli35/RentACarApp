using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CarDamages.Commands.CreateCarDamage
{
    public class CreateCarDamageCommandValidator : AbstractValidator<CreateCarDamageCommand>
    {
        public CreateCarDamageCommandValidator()
        {
            RuleFor(c => c.CarId).NotEmpty();
            RuleFor(c => c.DamageDetail).NotEmpty();
            RuleFor(c => c.DamageDetail).MaximumLength(500);
        }
    }
}
