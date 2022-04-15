using Application.Features.Cities.Dtos;
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

namespace Application.Features.Cities.Commands.UpdateCity
{
    public class UpdateCityCommand : IRequest<UpdateCityDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand, UpdateCityDto>
        {
            private readonly ICityRepository _cityRepository;
            private readonly IMapper _mapper;

            public UpdateCityCommandHandler(ICityRepository cityRepository, IMapper mapper)
            {
                _cityRepository = cityRepository;
                _mapper = mapper;
            }

            public async Task<UpdateCityDto> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
            {
                var updatedToBeCity = await _cityRepository.GetAsync(c => c.Id == request.Id);
                if (updatedToBeCity is null)
                    throw new BusinessException("Böyle bir şehir bulunamadı!");

                City mappedCity = _mapper.Map<City>(request);
                var updatedCity = _cityRepository.UpdateAsync(mappedCity);
                UpdateCityDto updateCityDto = _mapper.Map<UpdateCityDto>(updatedCity);
                return updateCityDto;
            }
        }
    }
}
