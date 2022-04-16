using Application.Features.Invoices.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Invoices.Commands.CreateInvoice
{
    public class CreateInvoiceCommand : IRequest<CreateInvoiceDto>
    {
        public int CustomerId { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime RentalStartDate { get; set; }
        public DateTime RentalEndDate { get; set; }
        public float RentalDayCount { get; set; }
        public decimal TotalRentalPrice { get; set; }

        public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, CreateInvoiceDto>
        {
            private readonly IInvoiceRepository _invoiceRepository;
            private readonly IMapper _mapper;

            public CreateInvoiceCommandHandler(IInvoiceRepository invoiceRepository, IMapper mapper)
            {
                _invoiceRepository = invoiceRepository;
                _mapper = mapper;
            }

            public async Task<CreateInvoiceDto> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
            {
                Invoice mappedInvoice = _mapper.Map<Invoice>(request);
                Invoice createdInvoice = await _invoiceRepository.AddAsync(mappedInvoice);
                CreateInvoiceDto createInvoiceDto = _mapper.Map<CreateInvoiceDto>(createdInvoice);
                return createInvoiceDto;
            }
        }
    }
}
