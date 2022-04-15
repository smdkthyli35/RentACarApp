using Application.Features.CarDamages.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CarDamages.Queries.GetCarDamageList
{
    public class GetCarDamageListQuery : IRequest<CarDamageListModel>, ICachableRequest
    {
        public PageRequest PageRequest { get; set; }

        public bool BypassCache { get; set; }
        public string CacheKey => "car-damages-list";
        public TimeSpan? SlidingExpiration { get; set; }

        public class GetCarDamageListQueryHandler : IRequestHandler<GetCarDamageListQuery, CarDamageListModel>
        {
            private readonly ICarDamageRepository _carDamageRepository;
            private readonly IMapper _mapper;

            public GetCarDamageListQueryHandler(ICarDamageRepository carDamageRepository, IMapper mapper)
            {
                _carDamageRepository = carDamageRepository;
                _mapper = mapper;
            }

            public async Task<CarDamageListModel> Handle(GetCarDamageListQuery request, CancellationToken cancellationToken)
            {
                var carDamages = await _carDamageRepository.GetListAsync(
                    include: c => c.Include(c => c.Car),
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

                var mappedCarDamages = _mapper.Map<CarDamageListModel>(carDamages);
                return mappedCarDamages;
            }
        }
    }
}
