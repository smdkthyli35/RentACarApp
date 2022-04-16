using Application.Features.Rentals.Models;
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

namespace Application.Features.Rentals.Queries.GetRentalList
{
    public class GetRentalListQuery : IRequest<RentalListModel>, ICachableRequest
    {
        public PageRequest PageRequest { get; set; }

        public bool BypassCache { get; set; }
        public string CacheKey => "rentals-list";
        public TimeSpan? SlidingExpiration { get; set; }

        public class GetRentalListQueryHandler : IRequestHandler<GetRentalListQuery, RentalListModel>
        {
            private readonly IRentalRepository _rentalRepsoitory;
            private readonly IMapper _mapper;

            public GetRentalListQueryHandler(IRentalRepository rentalRepsoitory, IMapper mapper)
            {
                _rentalRepsoitory = rentalRepsoitory;
                _mapper = mapper;
            }

            public async Task<RentalListModel> Handle(GetRentalListQuery request, CancellationToken cancellationToken)
            {
                var rentals = await _rentalRepsoitory.GetListAsync(
                    include: r => r.Include(r => r.Car).Include(r => r.Customer),
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

                RentalListModel rentalListModel = _mapper.Map<RentalListModel>(rentals);
                return rentalListModel;
            }
        }
    }
}
