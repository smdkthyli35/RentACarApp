using Application.Features.Cars.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Cars.Queries.GetCarList
{
    public class GetCarListQuery : IRequest<CarListModel>, ICachableRequest
    {
        public PageRequest PageRequest { get; set; }

        public bool BypassCache { get; set; }
        public string CacheKey => "cars-list";
        public TimeSpan? SlidingExpiration { get; set; }

        public class GetCarListQueryHandler : IRequestHandler<GetCarListQuery, CarListModel>
        {
            private readonly ICarRepository _carRepository;
            private readonly IMapper _mapper;

            public GetCarListQueryHandler(ICarRepository carRepository, IMapper mapper)
            {
                _carRepository = carRepository;
                _mapper = mapper;
            }

            public async Task<CarListModel> Handle(GetCarListQuery request, CancellationToken cancellationToken)
            {
                var cars = await _carRepository.GetListAsync(
                    c => c.CarState != CarState.Maintenance,
                    include: c => c.Include(c => c.Model).Include(c => c.Color),
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

                var mappedCars = _mapper.Map<CarListModel>(cars);
                return mappedCars;
            }
        }
    }
}
