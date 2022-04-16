using Application.Features.Brands.Dtos;
using Application.Features.Cities.Dtos;
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

namespace Application.Features.Cities.Queries.GetCityById
{
    public class GetCityByIdQuery : IRequest<CityDto>
    {
        public int Id { get; set; }

        public class GetCityByIdQueryHandler : IRequestHandler<GetCityByIdQuery, CityDto>
        {
            private readonly ICityRepository _cityRepository;
            private readonly IMapper _mapper;

            public GetCityByIdQueryHandler(ICityRepository cityRepository, IMapper mapper)
            {
                _cityRepository = cityRepository;
                _mapper = mapper;
            }

            public async Task<CityDto> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
            {
                var cityIsTheExists = await _cityRepository.GetAsync(b => b.Id == request.Id);
                if (cityIsTheExists is null)
                    throw new BusinessException($"{request.Id} id'li böyle şehir marka bulunamadı!");
                else
                {
                    CityDto cityDto = _mapper.Map<CityDto>(cityIsTheExists);
                    return cityDto;
                }
            }
        }
    }
}
