using Application.Features.Cars.Dtos;
using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Cars.Commands.CreateCar
{
    public class CreateCarCommand : IRequest<CreateCarDto>, ILoggableRequest
    {
        public int ColorId { get; set; }
        public int ModelId { get; set; }
        public string Plate { get; set; }
        public short ModelYear { get; set; }
        public CarState CarState { get; set; }

        public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, CreateCarDto>
        {
            private readonly ICarRepository _carRepository;
            private readonly IMapper _mapper;
            private readonly CarBusinessRules _carBusinessRules;

            public CreateCarCommandHandler(ICarRepository carRepository, IMapper mapper, CarBusinessRules carBusinessRules)
            {
                _carRepository = carRepository;
                _mapper = mapper;
                _carBusinessRules = carBusinessRules;
            }

            public async Task<CreateCarDto> Handle(CreateCarCommand request, CancellationToken cancellationToken)
            {
                await _carBusinessRules.PlateCanNotBeDuplicatedInsertedAndUpdated(request.Plate);

                Car mappedCar = _mapper.Map<Car>(request);
                Car createdCar = await _carRepository.AddAsync(mappedCar);
                CreateCarDto createCarDto = _mapper.Map<CreateCarDto>(createdCar);
                return createCarDto;
            }
        }
    }
}
