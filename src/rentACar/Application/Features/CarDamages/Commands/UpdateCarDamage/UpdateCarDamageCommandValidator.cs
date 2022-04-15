using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CarDamages.Commands.UpdateCarDamage
{
    public class UpdateCarDamageCommandValidator : AbstractValidator<UpdateCarDamageCommand>
    {
        public UpdateCarDamageCommandValidator()
        {
            RuleFor(c => c.CarId).NotEmpty();
            RuleFor(c => c.DamageDetail).NotEmpty();
            RuleFor(c => c.DamageDetail).MaximumLength(500);
        }
    }
}
