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

namespace Application.Features.Cities.Commands.DeleteCity
{
    public class DeleteCityCommand : IRequest<DeleteCityDto>
    {
        public int Id { get; set; }

        public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, DeleteCityDto>
        {
            private readonly ICityRepository _cityRepository;
            private readonly IMapper _mapper;

            public DeleteCityCommandHandler(ICityRepository cityRepository, IMapper mapper)
            {
                _cityRepository = cityRepository;
                _mapper = mapper;
            }

            public async Task<DeleteCityDto> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
            {
                var cityToBeDeleted = await _cityRepository.GetAsync(c => c.Id == request.Id);
                if (cityToBeDeleted is null)
                    throw new BusinessException("Böyle bir şehir bulunamadı!");

                City mappedCity = _mapper.Map<City>(request);
                var deletedCity = _cityRepository.DeleteAsync(mappedCity);
                DeleteCityDto deleteCityDto = _mapper.Map<DeleteCityDto>(deletedCity);
                return deleteCityDto;
            }
        }
    }
}
