using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Commands.CreateModel
{
    public class CreateModelCommandValidator : AbstractValidator<CreateModelCommand>
    {
        public CreateModelCommandValidator()
        {
            RuleFor(m => m.Name).NotEmpty();
            RuleFor(m => m.Name).MinimumLength(2);
            RuleFor(m => m.Name).MaximumLength(50);
            RuleFor(m => m.DailyPrice).GreaterThan(0);
            RuleFor(m => m.ImageUrl).NotEmpty();
            RuleFor(m => m.ImageUrl).MinimumLength(2);
            RuleFor(m => m.ImageUrl).MaximumLength(250);
        }
    }
}
