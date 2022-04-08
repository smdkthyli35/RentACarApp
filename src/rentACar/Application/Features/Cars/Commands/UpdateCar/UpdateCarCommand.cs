using Application.Features.Cars.Dtos;
using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Cars.Commands.UpdateCar
{
    public class UpdateCarCommand : IRequest<UpdateCarDto>
    {
        public int Id { get; set; }
        public int ColorId { get; set; }
        public int ModelId { get; set; }
        public string Plate { get; set; }
        public short ModelYear { get; set; }
        public CarState CarState { get; set; }

        public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, UpdateCarDto>
        {
            private readonly ICarRepository _carRepository;
            private readonly IMapper _mapper;
            private readonly CarBusinessRules _carBusinessRules;

            public UpdateCarCommandHandler(ICarRepository carRepository, IMapper mapper, CarBusinessRules carBusinessRules)
            {
                _carRepository = carRepository;
                _mapper = mapper;
                _carBusinessRules = carBusinessRules;
            }

            public async Task<UpdateCarDto> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
            {
                var carToBeUpdated = await _carRepository.GetAsync(c => c.Id == request.Id);
                if (carToBeUpdated is null)
                    throw new BusinessException("Böyle bir araba bulunamadı!");

                await _carBusinessRules.PlateCanNotBeDuplicatedInsertedAndUpdated(request.Plate);

                Car mappedCar = _mapper.Map<Car>(request);
                var updatedCar = _carRepository.UpdateAsync(mappedCar);
                UpdateCarDto updateCarDto = _mapper.Map<UpdateCarDto>(updatedCar);
                return updateCarDto;
            }
        }
    }
}
