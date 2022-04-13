using Application.Features.InvidualCustomers.Models;
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

namespace Application.Features.InvidualCustomers.Queries.GetInvidualCustomerList
{
    public class GetInvidualCustomerListQuery : IRequest<InvidualCustomerListModel>, ICachableRequest
    {
        public PageRequest PageRequest { get; set; }

        public bool BypassCache { get; set; }
        public string CacheKey => "invidual-customers-list";
        public TimeSpan? SlidingExpiration { get; set; }

        public class GetInvidualCustomerListQueryHandler : IRequestHandler<GetInvidualCustomerListQuery, InvidualCustomerListModel>
        {
            private readonly IInvidualCustomerRepository _invidualCustomerRepository;
            private readonly IMapper _mapper;

            public GetInvidualCustomerListQueryHandler(IInvidualCustomerRepository invidualCustomerRepository, IMapper mapper)
            {
                _invidualCustomerRepository = invidualCustomerRepository;
                _mapper = mapper;
            }

            public async Task<InvidualCustomerListModel> Handle(GetInvidualCustomerListQuery request, CancellationToken cancellationToken)
            {
                var invidualCustomers = await _invidualCustomerRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

                var mappedInvidualCustomers = _mapper.Map<InvidualCustomerListModel>(invidualCustomers);
                return mappedInvidualCustomers;
            }
        }
    }
}
