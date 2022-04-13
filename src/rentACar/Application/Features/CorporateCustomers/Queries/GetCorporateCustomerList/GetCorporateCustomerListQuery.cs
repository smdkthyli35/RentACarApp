using Application.Features.CorporateCustomers.Models;
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

namespace Application.Features.CorporateCustomers.Queries.GetCorporateCustomerList
{
    public class GetCorporateCustomerListQuery : IRequest<CorporateCustomerListModel>, ICachableRequest
    {
        public PageRequest PageRequest { get; set; }

        public bool BypassCache { get; set; }
        public string CacheKey => "corporate-customers-list";
        public TimeSpan? SlidingExpiration { get; set; }

        public class GetCorporateCustomerListQueryHandler : IRequestHandler<GetCorporateCustomerListQuery, CorporateCustomerListModel>
        {
            private readonly ICorporateCustomerRepository _corporateCustomerRepository;
            private readonly IMapper _mapper;

            public GetCorporateCustomerListQueryHandler(ICorporateCustomerRepository corporateCustomerRepository, IMapper mapper)
            {
                _corporateCustomerRepository = corporateCustomerRepository;
                _mapper = mapper;
            }

            public async Task<CorporateCustomerListModel> Handle(GetCorporateCustomerListQuery request, CancellationToken cancellationToken)
            {
                var corporateCustomers = await _corporateCustomerRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

                var mappedCorporateCustomers = _mapper.Map<CorporateCustomerListModel>(corporateCustomers);
                return mappedCorporateCustomers;
            }
        }
    }
}
