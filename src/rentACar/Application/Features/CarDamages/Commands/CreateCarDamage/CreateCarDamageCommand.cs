using Application.Features.CarDamages.Dtos;
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

namespace Application.Features.CarDamages.Commands.CreateCarDamage
{
    public class CreateCarDamageCommand : IRequest<CreateCarDamageDto>
    {
        public int CarId { get; set; }
        public string DamageDetail { get; set; }

        public class CreateCarDamageCommandHandler : IRequestHandler<CreateCarDamageCommand, CreateCarDamageDto>
        {
            private readonly ICarDamageRepository _carDamageRepository;
            private readonly IMapper _mapper;

            public CreateCarDamageCommandHandler(ICarDamageRepository carDamageRepository, IMapper mapper)
            {
                _carDamageRepository = carDamageRepository;
                _mapper = mapper;
            }

            public async Task<CreateCarDamageDto> Handle(CreateCarDamageCommand request, CancellationToken cancellationToken)
            {
                CarDamage mappedCarDamage = _mapper.Map<CarDamage>(request);
                CarDamage createdCarDamage = await _carDamageRepository.AddAsync(mappedCarDamage);
                CreateCarDamageDto createCarDamageDto = _mapper.Map<CreateCarDamageDto>(createdCarDamage);
                return createCarDamageDto;
            }
        }
    }
}
