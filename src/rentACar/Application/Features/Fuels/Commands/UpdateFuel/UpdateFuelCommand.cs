using Application.Features.Fuels.Dtos;
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

namespace Application.Features.Fuels.Commands.UpdateFuel
{
    public class UpdateFuelCommand : IRequest<UpdateFuelDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateFuelCommandHandler : IRequestHandler<UpdateFuelCommand, UpdateFuelDto>
        {
            private readonly IFuelRepository _fuelRepository;
            private readonly IMapper _mapper;

            public UpdateFuelCommandHandler(IFuelRepository fuelRepository, IMapper mapper)
            {
                _fuelRepository = fuelRepository;
                _mapper = mapper;
            }

            public async Task<UpdateFuelDto> Handle(UpdateFuelCommand request, CancellationToken cancellationToken)
            {
                var fuelToBeUpdated = await _fuelRepository.GetAsync(f => f.Id == request.Id);
                if (fuelToBeUpdated is null)
                    throw new BusinessException("Böyle bir yakıt türü bulunamadı!");

                Fuel mappedFuel = _mapper.Map<Fuel>(request);
                var updatedFuel = _fuelRepository.UpdateAsync(mappedFuel);
                UpdateFuelDto updateFuelDto = _mapper.Map<UpdateFuelDto>(updatedFuel);
                return updateFuelDto;
            }
        }
    }
}
