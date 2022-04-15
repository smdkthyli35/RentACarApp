using Application.Features.CarDamages.Dtos;
using Application.Features.CarDamages.Rules;
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

namespace Application.Features.CarDamages.Commands.CreateCarDamage
{
    public class CreateCarDamageCommand : IRequest<CreateCarDamageDto>, ILoggableRequest
    {
        public int CarId { get; set; }
        public string DamageDetail { get; set; }

        public class CreateCarDamageCommandHandler : IRequestHandler<CreateCarDamageCommand, CreateCarDamageDto>
        {
            private readonly ICarDamageRepository _carDamageRepository;
            private readonly IMapper _mapper;
            private readonly CarDamageBusinessRules _carDamageBusinessRules;

            public CreateCarDamageCommandHandler(ICarDamageRepository carDamageRepository, IMapper mapper, CarDamageBusinessRules carDamageBusinessRules)
            {
                _carDamageRepository = carDamageRepository;
                _mapper = mapper;
                _carDamageBusinessRules = carDamageBusinessRules;
            }

            public async Task<CreateCarDamageDto> Handle(CreateCarDamageCommand request, CancellationToken cancellationToken)
            {
                await _carDamageBusinessRules.CarIdCanNotBeNull(request.CarId);

                CarDamage mappedCarDamage = _mapper.Map<CarDamage>(request);
                CarDamage createdCarDamage = await _carDamageRepository.AddAsync(mappedCarDamage);
                CreateCarDamageDto createCarDamageDto = _mapper.Map<CreateCarDamageDto>(createdCarDamage);
                return createCarDamageDto;
            }
        }
    }
}
