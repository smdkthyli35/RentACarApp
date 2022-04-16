using Application.Features.Brands.Dtos;
using Application.Features.Rentals.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Rentals.Queries.GetRentalById
{
    public class GetRentalByIdQuery : IRequest<RentalDto>
    {
        public int Id { get; set; }

        public class GetRentalByIdQueryHandler : IRequestHandler<GetRentalByIdQuery, RentalDto>
        {
            private readonly IRentalRepository _rentalRepsoitory;
            private readonly IMapper _mapper;

            public GetRentalByIdQueryHandler(IRentalRepository rentalRepsoitory, IMapper mapper)
            {
                _rentalRepsoitory = rentalRepsoitory;
                _mapper = mapper;
            }

            public async Task<RentalDto> Handle(GetRentalByIdQuery request, CancellationToken cancellationToken)
            {
                var rentalIsTheExists = await _rentalRepsoitory.GetAsync(b => b.Id == request.Id);
                if (rentalIsTheExists is null)
                    throw new BusinessException($"{request.Id} id'li böyle bir kiralama bilgisi bulunamadı!");
                else
                {
                    RentalDto rentalDto = _mapper.Map<RentalDto>(rentalIsTheExists);
                    return rentalDto;
                }
            }
        }
    }
}
