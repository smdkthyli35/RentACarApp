using Application.Features.Brands.Dtos;
using Application.Features.Invoices.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Invoices.Queries.GetInvoiceById
{
    public class GetInvoiceByIdQuery : IRequest<InvoiceDto>
    {
        public int Id { get; set; }

        public class GetInvoiceByIdQueryHandler : IRequestHandler<GetInvoiceByIdQuery, InvoiceDto>
        {
            private readonly IInvoiceRepository _invoiceRepository;
            private readonly IMapper _mapper;

            public GetInvoiceByIdQueryHandler(IInvoiceRepository invoiceRepository, IMapper mapper)
            {
                _invoiceRepository = invoiceRepository;
                _mapper = mapper;
            }

            public async Task<InvoiceDto> Handle(GetInvoiceByIdQuery request, CancellationToken cancellationToken)
            {
                var invoiceIsTheExists = await _invoiceRepository.GetAsync(b => b.Id == request.Id);
                if (invoiceIsTheExists is null)
                    throw new BusinessException($"{request.Id} id'li böyle bir fatura bilgisi bulunamadı!");
                else
                {
                    InvoiceDto invoiceDto = _mapper.Map<InvoiceDto>(invoiceIsTheExists);
                    return invoiceDto;
                }
            }
        }
    }
}
