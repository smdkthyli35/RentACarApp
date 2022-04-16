using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Rentals.Commands.CreateRental
{
    public class CreateRentalCommandValidator : AbstractValidator<CreateRentalCommand>
    {
        public CreateRentalCommandValidator()
        {
            RuleFor(r => r.RentedCity).NotEmpty();
            RuleFor(r => r.RentedCity).MaximumLength(50);
            RuleFor(r => r.DeliveryCity).NotEmpty();
            RuleFor(r => r.DeliveryCity).MaximumLength(50);
            RuleFor(r => r.StartDate).GreaterThan(DateTime.Now).LessThan(c => c.EndDate);
            RuleFor(r => r.EndDate).GreaterThan(r => r.StartDate);
        }
    }
}
