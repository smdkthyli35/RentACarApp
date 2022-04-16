using Application.Features.Brands.Dtos;
using Application.Features.CarDamages.Dtos;
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

namespace Application.Features.CarDamages.Queries.GetCarDamageById
{
    public class GetCarDamageByIdQuery : IRequest<CarDamageDto>
    {
        public int Id { get; set; }

        public class GetCarDamageByIdQueryHandler : IRequestHandler<GetCarDamageByIdQuery, CarDamageDto>
        {
            private readonly ICarDamageRepository _carDamageRepository;
            private readonly IMapper _mapper;

            public GetCarDamageByIdQueryHandler(ICarDamageRepository carDamageRepository, IMapper mapper)
            {
                _carDamageRepository = carDamageRepository;
                _mapper = mapper;
            }

            public async Task<CarDamageDto> Handle(GetCarDamageByIdQuery request, CancellationToken cancellationToken)
            {
                var carDamageIsTheExists = await _carDamageRepository.GetAsync(b => b.Id == request.Id);
                if (carDamageIsTheExists is null)
                    throw new BusinessException($"{request.Id} id'li bir hasar kaydı bulunamadı!");
                else
                {
                    CarDamageDto carDamageDto = _mapper.Map<CarDamageDto>(carDamageIsTheExists);
                    return carDamageDto;
                }
            }
        }
    }
}
