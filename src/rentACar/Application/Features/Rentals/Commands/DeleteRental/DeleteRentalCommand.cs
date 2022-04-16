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

namespace Application.Features.Rentals.Commands.DeleteRental
{
    public class DeleteRentalCommand : IRequest<DeleteRentalDto>
    {
        public int Id { get; set; }

        public class DeleteRentalCommandHandler : IRequestHandler<DeleteRentalCommand, DeleteRentalDto>
        {
            private readonly IRentalRepository _rentalRepsoitory;
            private readonly IMapper _mapper;

            public DeleteRentalCommandHandler(IRentalRepository rentalRepsoitory, IMapper mapper)
            {
                _rentalRepsoitory = rentalRepsoitory;
                _mapper = mapper;
            }

            public async Task<DeleteRentalDto> Handle(DeleteRentalCommand request, CancellationToken cancellationToken)
            {
                var rentalToBeDeleted = await _rentalRepsoitory.GetAsync(r => r.Id == request.Id);
                if (rentalToBeDeleted is null)
                    throw new BusinessException("Böyle bir araba kira bilgisi bulunamadı.");

                Rental mappedRental = _mapper.Map<Rental>(request);
                var deletedRental = _rentalRepsoitory.DeleteAsync(mappedRental);
                DeleteRentalDto deleteRentalDto = _mapper.Map<DeleteRentalDto>(deletedRental);
                return deleteRentalDto;
            }
        }
    }
}
