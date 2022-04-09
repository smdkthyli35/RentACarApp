using Application.Features.Fuels.Dtos;
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

namespace Application.Features.Fuels.Commands.CreateFuel
{
    public class CreateFuelCommand : IRequest<CreateFuelDto>
    {
        public string Name { get; set; }

        public class CreateFuelCommandHandler : IRequestHandler<CreateFuelCommand, CreateFuelDto>
        {
            private readonly IFuelRepository _fuelRepository;
            private readonly IMapper _mapper;

            public CreateFuelCommandHandler(IFuelRepository fuelRepository, IMapper mapper)
            {
                _fuelRepository = fuelRepository;
                _mapper = mapper;
            }

            public async Task<CreateFuelDto> Handle(CreateFuelCommand request, CancellationToken cancellationToken)
            {
                Fuel mappedFuel = _mapper.Map<Fuel>(request);
                Fuel createdFuel = await _fuelRepository.AddAsync(mappedFuel);
                CreateFuelDto createFuelDto = _mapper.Map<CreateFuelDto>(createdFuel);
                return createFuelDto;
            }
        }
    }
}
