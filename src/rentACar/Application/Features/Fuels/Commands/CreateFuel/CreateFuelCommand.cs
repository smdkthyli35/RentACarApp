using Application.Features.Fuels.Dtos;
using Application.Features.Fuels.Rules;
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

namespace Application.Features.Fuels.Commands.CreateFuel
{
    public class CreateFuelCommand : IRequest<CreateFuelDto>, ILoggableRequest
    {
        public string Name { get; set; }

        public class CreateFuelCommandHandler : IRequestHandler<CreateFuelCommand, CreateFuelDto>
        {
            private readonly IFuelRepository _fuelRepository;
            private readonly IMapper _mapper;
            private readonly FuelBusinessRules _fuelBusinessRules;

            public CreateFuelCommandHandler(IFuelRepository fuelRepository, IMapper mapper, FuelBusinessRules fuelBusinessRules)
            {
                _fuelRepository = fuelRepository;
                _mapper = mapper;
                _fuelBusinessRules = fuelBusinessRules;
            }

            public async Task<CreateFuelDto> Handle(CreateFuelCommand request, CancellationToken cancellationToken)
            {
                await _fuelBusinessRules.FuelNameCanNotBeDuplicatedWhenInserted(request.Name);

                Fuel mappedFuel = _mapper.Map<Fuel>(request);
                Fuel createdFuel = await _fuelRepository.AddAsync(mappedFuel);
                CreateFuelDto createFuelDto = _mapper.Map<CreateFuelDto>(createdFuel);
                return createFuelDto;
            }
        }
    }
}
