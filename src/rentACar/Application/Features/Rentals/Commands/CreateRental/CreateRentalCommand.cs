using Application.Features.Rentals.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Rentals.Commands.CreateRental
{
    public class CreateRentalCommand : IRequest<CreateRentalDto>
    {
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string RentedCity { get; set; }
        public string DeliveryCity { get; set; }
        public int RentStartKilometer { get; set; }
        public int? RentEndKilometer { get; set; }

        public class CreateRentalCommandHandler : IRequestHandler<CreateRentalCommand, CreateRentalDto>
        {
            private readonly IRentalRepsoitory _rentalRepsoitory;
            private readonly IMapper _mapper;

            public CreateRentalCommandHandler(IRentalRepsoitory rentalRepsoitory, IMapper mapper)
            {
                _rentalRepsoitory = rentalRepsoitory;
                _mapper = mapper;
            }

            public async Task<CreateRentalDto> Handle(CreateRentalCommand request, CancellationToken cancellationToken)
            {
                Rental mappedRental = _mapper.Map<Rental>(request);
                Rental createdRental = await _rentalRepsoitory.AddAsync(mappedRental);
                CreateRentalDto createRentalDto = _mapper.Map<CreateRentalDto>(createdRental);
                return createRentalDto;
            }
        }
    }
}
