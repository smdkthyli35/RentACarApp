using Application.Features.AdditionalServices.Models;
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

namespace Application.Features.AdditionalServices.Queries.GetAdditionalServiceList
{
    public class GetAdditionalServiceListQuery : IRequest<AdditionalServiceListModel>, ICachableRequest
    {
        public PageRequest PageRequest { get; set; }

        public bool BypassCache { get; set; }
        public string CacheKey => "additional-services-list";
        public TimeSpan? SlidingExpiration { get; set; }

        public class GetAdditionalServiceListQueryHandler : IRequestHandler<GetAdditionalServiceListQuery, AdditionalServiceListModel>
        {
            private readonly IAdditionalServiceRepository _additionalServiceRepository;
            private readonly IMapper _mapper;

            public GetAdditionalServiceListQueryHandler(IAdditionalServiceRepository additionalServiceRepository, IMapper mapper)
            {
                _additionalServiceRepository = additionalServiceRepository;
                _mapper = mapper;
            }

            public async Task<AdditionalServiceListModel> Handle(GetAdditionalServiceListQuery request, CancellationToken cancellationToken)
            {
                var additionalServices = await _additionalServiceRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

                var mappedAdditionalServices = _mapper.Map<AdditionalServiceListModel>(additionalServices);
                return mappedAdditionalServices;
            }
        }
    }
}
