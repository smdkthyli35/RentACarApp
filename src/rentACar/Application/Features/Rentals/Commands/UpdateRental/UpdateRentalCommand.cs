using Application.Features.Rentals.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Rentals.Commands.UpdateRental
{
    public class UpdateRentalCommand : IRequest<UpdateRentalDto>
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string RentedCity { get; set; }
        public string DeliveryCity { get; set; }
        public int RentStartKilometer { get; set; }
        public int? RentEndKilometer { get; set; }

        public class UpdateRentalCommandHandler : IRequestHandler<UpdateRentalCommand, UpdateRentalDto>
        {
            private readonly IRentalRepsoitory _rentalRepsoitory;
            private readonly IMapper _mapper;

            public UpdateRentalCommandHandler(IRentalRepsoitory rentalRepsoitory, IMapper mapper)
            {
                _rentalRepsoitory = rentalRepsoitory;
                _mapper = mapper;
            }

            public async Task<UpdateRentalDto> Handle(UpdateRentalCommand request, CancellationToken cancellationToken)
            {
                var rentalToBeUpdated = await _rentalRepsoitory.GetAsync(r => r.Id == request.Id);
                if (rentalToBeUpdated is null)
                    throw new BusinessException("Böyle bir araba kira bilgisi bulunamadı.");

                Rental mappedRental = _mapper.Map<Rental>(request);
                var updatedRental = _rentalRepsoitory.UpdateAsync(mappedRental);
                UpdateRentalDto updateRentalDto = _mapper.Map<UpdateRentalDto>(updatedRental);
                return updateRentalDto;
            }
        }
    }
}
