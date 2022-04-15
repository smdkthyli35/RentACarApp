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

namespace Application.Features.CarDamages.Commands.DeleteCarDamage
{
    public class DeleteCarDamageCommand : IRequest<DeleteCarDamageDto>
    {
        public int Id { get; set; }

        public class DeleteCarDamageCommandHandler : IRequestHandler<DeleteCarDamageCommand, DeleteCarDamageDto>
        {
            private readonly ICarDamageRepository _carDamageRepository;
            private readonly IMapper _mapper;

            public DeleteCarDamageCommandHandler(ICarDamageRepository carDamageRepository, IMapper mapper)
            {
                _carDamageRepository = carDamageRepository;
                _mapper = mapper;
            }

            public async Task<DeleteCarDamageDto> Handle(DeleteCarDamageCommand request, CancellationToken cancellationToken)
            {
                var carDamageToBeDeleted = await _carDamageRepository.GetAsync(c => c.Id == request.Id);
                if (carDamageToBeDeleted is null)
                    throw new BusinessException("Böyle bir hasar kaydı bulunamadı!");

                CarDamage mappedCarDamage = _mapper.Map<CarDamage>(request);
                var deletedCarDamage = _carDamageRepository.DeleteAsync(mappedCarDamage);
                DeleteCarDamageDto deleteCarDamageDto = _mapper.Map<DeleteCarDamageDto>(deletedCarDamage);
                return deleteCarDamageDto;
            }
        }
    }
}
