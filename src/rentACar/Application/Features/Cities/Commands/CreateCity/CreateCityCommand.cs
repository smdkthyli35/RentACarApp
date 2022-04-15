using Application.Features.Cities.Dtos;
using Application.Features.Cities.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Logging;
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
    public class CreateCityCommand : IRequest<CreateCityDto>, ILoggableRequest
    {
        public string Name { get; set; }

        public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, CreateCityDto>
        {
            private readonly ICityRepository _cityRepository;
            private readonly IMapper _mapper;
            private readonly CityBusinessRules _cityBusinessRules;

            public CreateCityCommandHandler(ICityRepository cityRepository, IMapper mapper, CityBusinessRules cityBusinessRules)
            {
                _cityRepository = cityRepository;
                _mapper = mapper;
                _cityBusinessRules = cityBusinessRules;
            }

            public async Task<CreateCityDto> Handle(CreateCityCommand request, CancellationToken cancellationToken)
            {
                await _cityBusinessRules.CityNameCanNotBeDuplicatedWhenInserted(request.Name);

                City mappedCity = _mapper.Map<City>(request);
                City createdCity = await _cityRepository.AddAsync(mappedCity);
                CreateCityDto createCityDto = _mapper.Map<CreateCityDto>(createdCity);
                return createCityDto;
            }
        }
    }
}
