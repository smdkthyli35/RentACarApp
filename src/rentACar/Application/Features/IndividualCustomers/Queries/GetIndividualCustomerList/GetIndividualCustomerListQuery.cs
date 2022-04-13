﻿using Application.Features.IndividualCustomers.Models;
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

namespace Application.Features.IndividualCustomers.Queries.GetIndividualCustomerList
{
    public class GetIndividualCustomerListQuery : IRequest<IndividualCustomerListModel>, ICachableRequest
    {
        public PageRequest PageRequest { get; set; }

        public bool BypassCache { get; set; }
        public string CacheKey => "invidual-customers-list";
        public TimeSpan? SlidingExpiration { get; set; }

        public class GetIndividualCustomerListQueryHandler : IRequestHandler<GetIndividualCustomerListQuery, IndividualCustomerListModel>
        {
            private readonly IIndividualCustomerRepository _individualCustomerRepository;
            private readonly IMapper _mapper;

            public GetIndividualCustomerListQueryHandler(IIndividualCustomerRepository individualCustomerRepository, IMapper mapper)
            {
                _individualCustomerRepository = individualCustomerRepository;
                _mapper = mapper;
            }

            public async Task<IndividualCustomerListModel> Handle(GetIndividualCustomerListQuery request, CancellationToken cancellationToken)
            {
                var invidualCustomers = await _individualCustomerRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

                var mappedInvidualCustomers = _mapper.Map<IndividualCustomerListModel>(invidualCustomers);
                return mappedInvidualCustomers;
            }
        }
    }
}
