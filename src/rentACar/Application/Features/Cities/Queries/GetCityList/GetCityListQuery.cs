using Application.Features.Cities.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Cities.Queries.GetCityList
{
    public class GetCityListQuery : IRequest<CityListModel>, ICachableRequest
    {
        public PageRequest PageRequest { get; set; }

        public bool BypassCache { get; set; }
        public string CacheKey => "cities-list";
        public TimeSpan? SlidingExpiration { get; set; }

        public class GetCityListQueryHandler : IRequestHandler<GetCityListQuery, CityListModel>
        {
            private readonly ICityRepository _cityRepository;
            private readonly IMapper _mapper;

            public GetCityListQueryHandler(ICityRepository cityRepository, IMapper mapper)
            {
                _cityRepository = cityRepository;
                _mapper = mapper;
            }

            public async Task<CityListModel> Handle(GetCityListQuery request, CancellationToken cancellationToken)
            {
                var cities = await _cityRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

                var mappedCities = _mapper.Map<CityListModel>(cities);
                return mappedCities;
            }
        }
    }
}
