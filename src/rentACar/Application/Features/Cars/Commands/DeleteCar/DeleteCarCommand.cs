using Application.Features.Cars.Dtos;
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

namespace Application.Features.Cars.Commands.DeleteCar
{
    public class DeleteCarCommand : IRequest<DeleteCarDto>
    {
        public int Id { get; set; }

        public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, DeleteCarDto>
        {
            private readonly ICarRepository _carRepository;
            private readonly IMapper _mapper;

            public DeleteCarCommandHandler(ICarRepository carRepository, IMapper mapper)
            {
                _carRepository = carRepository;
                _mapper = mapper;
            }

            public async Task<DeleteCarDto> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
            {
                var carToBeDeleted = await _carRepository.GetAsync(c => c.Id == request.Id);
                if (carToBeDeleted is null)
                    throw new BusinessException("Böyle bir araba bulunamadı!");

                Car mappedCar = _mapper.Map<Car>(request);
                var deletedCar = _carRepository.DeleteAsync(mappedCar);
                DeleteCarDto deleteCarDto = _mapper.Map<DeleteCarDto>(deletedCar);
                return deleteCarDto;
            }
        }
    }
}
