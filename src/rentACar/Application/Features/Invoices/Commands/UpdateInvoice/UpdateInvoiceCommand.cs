using Application.Features.Invoices.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Invoices.Commands.UpdateInvoice
{
    public class UpdateInvoiceCommand : IRequest<UpdateInvoiceDto>
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime RentalStartDate { get; set; }
        public DateTime RentalEndDate { get; set; }
        public float RentalDayCount { get; set; }
        public decimal TotalRentalPrice { get; set; }

        public class UpdateInvoiceCommandHandler : IRequestHandler<UpdateInvoiceCommand, UpdateInvoiceDto>
        {
            private readonly IInvoiceRepository _invoiceRepository;
            private readonly IMapper _mapper;

            public UpdateInvoiceCommandHandler(IInvoiceRepository invoiceRepository, IMapper mapper)
            {
                _invoiceRepository = invoiceRepository;
                _mapper = mapper;
            }

            public async Task<UpdateInvoiceDto> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
            {
                var invoiceToBeUpdated = await _invoiceRepository.GetAsync(i => i.Id == request.Id);
                if (invoiceToBeUpdated is null)
                    throw new BusinessException("Böyle bir fatura bulunamadı!");

                Invoice mappedInvoice = _mapper.Map<Invoice>(request);
                var updatedInvoice = _invoiceRepository.UpdateAsync(mappedInvoice);
                UpdateInvoiceDto updateInvoiceDto = _mapper.Map<UpdateInvoiceDto>(updatedInvoice);
                return updateInvoiceDto;
            }
        }
    }
}
