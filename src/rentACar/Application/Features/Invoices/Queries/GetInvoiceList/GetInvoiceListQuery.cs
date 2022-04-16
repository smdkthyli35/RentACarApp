using Application.Features.Invoices.Models;
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

namespace Application.Features.Invoices.Queries.GetInvoiceList
{
    public class GetInvoiceListQuery : IRequest<InvoiceListModel>, ICachableRequest
    {
        public PageRequest PageRequest { get; set; }

        public bool BypassCache { get; set; }
        public string CacheKey => "invoices-list";
        public TimeSpan? SlidingExpiration { get; set; }

        public class GetInvoiceListQueryHandler : IRequestHandler<GetInvoiceListQuery, InvoiceListModel>
        {
            private readonly IInvoiceRepository _invoiceRepository;
            private readonly IMapper _mapper;

            public GetInvoiceListQueryHandler(IInvoiceRepository invoiceRepository, IMapper mapper)
            {
                _invoiceRepository = invoiceRepository;
                _mapper = mapper;
            }

            public async Task<InvoiceListModel> Handle(GetInvoiceListQuery request, CancellationToken cancellationToken)
            {
                var invoices = await _invoiceRepository.GetListAsync(
                    include: i => i.Include(i => i.Customer),
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

                InvoiceListModel mappedInvoiceListModel = _mapper.Map<InvoiceListModel>(invoices);
                return mappedInvoiceListModel;
            }
        }
    }
}
