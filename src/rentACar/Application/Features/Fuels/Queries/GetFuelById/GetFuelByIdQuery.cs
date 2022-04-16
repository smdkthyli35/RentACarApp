using Application.Features.Brands.Dtos;
using Application.Features.Fuels.Dtos;
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

namespace Application.Features.Fuels.Queries.GetFuelById
{
    public class GetFuelByIdQuery : IRequest<FuelDto>
    {
        public int Id { get; set; }

        public class GetFuelByIdQueryHandler : IRequestHandler<GetFuelByIdQuery, FuelDto>
        {
            private readonly IFuelRepository _fuelRepository;
            private readonly IMapper _mapper;

            public GetFuelByIdQueryHandler(IFuelRepository fuelRepository, IMapper mapper)
            {
                _fuelRepository = fuelRepository;
                _mapper = mapper;
            }

            public async Task<FuelDto> Handle(GetFuelByIdQuery request, CancellationToken cancellationToken)
            {
                var fuelIsTheExists = await _fuelRepository.GetAsync(b => b.Id == request.Id);
                if (fuelIsTheExists is null)
                    throw new BusinessException($"{request.Id} id'li böyle bir yakıt bilgisi bulunamadı!");
                else
                {
                    FuelDto fuelDto = _mapper.Map<FuelDto>(fuelIsTheExists);
                    return fuelDto;
                }
            }
        }
    }
}
