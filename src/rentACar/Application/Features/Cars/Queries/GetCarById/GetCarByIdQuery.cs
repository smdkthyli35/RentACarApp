using Application.Features.Brands.Dtos;
using Application.Features.Cars.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Cars.Queries.GetCarById
{
    public class GetCarByIdQuery : IRequest<CarDto>
    {
        public int Id { get; set; }

        public class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQuery, CarDto>
        {
            private readonly ICarRepository _carRepository;
            private readonly IMapper _mapper;

            public GetCarByIdQueryHandler(ICarRepository carRepository, IMapper mapper)
            {
                _carRepository = carRepository;
                _mapper = mapper;
            }

            public async Task<CarDto> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
            {
                var carIsTheExists = await _carRepository.GetAsync(b => b.Id == request.Id);
                if (carIsTheExists is null)
                    throw new BusinessException($"{request.Id} id'li böyle bir araba bulunamadı!");
                else
                {
                    CarDto carDto = _mapper.Map<CarDto>(carIsTheExists);
                    return carDto;
                }
            }
        }
    }
}
