using Application.Features.Cities.Dtos;
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

namespace Application.Features.Cities.Commands.CreateCity
{
    public class CreateCityCommand : IRequest<CreateCityDto>
    {
        public string Name { get; set; }

        public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, CreateCityDto>
        {
            private readonly ICityRepository _cityRepository;
            private readonly IMapper _mapper;

            public CreateCityCommandHandler(ICityRepository cityRepository, IMapper mapper)
            {
                _cityRepository = cityRepository;
                _mapper = mapper;
            }

            public async Task<CreateCityDto> Handle(CreateCityCommand request, CancellationToken cancellationToken)
            {
                City mappedCity = _mapper.Map<City>(request);
                City createdCity = await _cityRepository.AddAsync(mappedCity);
                CreateCityDto createCityDto = _mapper.Map<CreateCityDto>(createdCity);
                return createCityDto;
            }
        }
    }
}
