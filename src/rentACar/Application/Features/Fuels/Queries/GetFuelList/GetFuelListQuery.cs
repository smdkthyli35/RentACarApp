using Application.Features.Fuels.Models;
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

namespace Application.Features.Fuels.Queries.GetFuelList
{
    public class GetFuelListQuery : IRequest<FuelListModel>, ICachableRequest
    {
        public PageRequest PageRequest { get; set; }

        public bool BypassCache { get; set; }
        public string CacheKey => "fuels-list";
        public TimeSpan? SlidingExpiration { get; set; }

        public class GetFuelListQueryHandler : IRequestHandler<GetFuelListQuery, FuelListModel>
        {
            private readonly IFuelRepository _fuelRepository;
            private readonly IMapper _mapper;

            public GetFuelListQueryHandler(IFuelRepository fuelRepository, IMapper mapper)
            {
                _fuelRepository = fuelRepository;
                _mapper = mapper;
            }

            public async Task<FuelListModel> Handle(GetFuelListQuery request, CancellationToken cancellationToken)
            {
                var fuels = await _fuelRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

                var mappedFuels = _mapper.Map<FuelListModel>(fuels);
                return mappedFuels;
            }
        }
    }
}
