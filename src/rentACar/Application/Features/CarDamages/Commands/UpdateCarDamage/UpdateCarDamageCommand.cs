using Application.Features.CarDamages.Dtos;
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

namespace Application.Features.CarDamages.Commands.UpdateCarDamage
{
    public class UpdateCarDamageCommand : IRequest<UpdateCarDamageDto>
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string DamageDetail { get; set; }

        public class UpdateCarDamageCommandHandler : IRequestHandler<UpdateCarDamageCommand, UpdateCarDamageDto>
        {
            private readonly ICarDamageRepository _carDamageRepository;
            private readonly IMapper _mapper;

            public UpdateCarDamageCommandHandler(ICarDamageRepository carDamageRepository, IMapper mapper)
            {
                _carDamageRepository = carDamageRepository;
                _mapper = mapper;
            }

            public async Task<UpdateCarDamageDto> Handle(UpdateCarDamageCommand request, CancellationToken cancellationToken)
            {
                var carDamageToBeUpdated = await _carDamageRepository.GetAsync(c => c.Id == request.Id);
                if (carDamageToBeUpdated is null)
                    throw new BusinessException("Böyle bir hasar kaydı bulunamadı!");

                CarDamage mappedCarDamage = _mapper.Map<CarDamage>(request);
                var updatedCarDamage = _carDamageRepository.UpdateAsync(mappedCarDamage);
                UpdateCarDamageDto deleteCarDamageDto = _mapper.Map<UpdateCarDamageDto>(updatedCarDamage);
                return deleteCarDamageDto;
            }
        }
    }
}
