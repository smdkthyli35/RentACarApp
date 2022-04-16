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

namespace Application.Features.Invoices.Commands.DeleteInvoice
{
    public class DeleteInvoiceCommand : IRequest<DeleteInvoiceDto>
    {
        public int Id { get; set; }

        public class DeleteInvoiceCommandHandler : IRequestHandler<DeleteInvoiceCommand, DeleteInvoiceDto>
        {
            private readonly IInvoiceRepository _invoiceRepository;
            private readonly IMapper _mapper;

            public DeleteInvoiceCommandHandler(IInvoiceRepository invoiceRepository, IMapper mapper)
            {
                _invoiceRepository = invoiceRepository;
                _mapper = mapper;
            }

            public async Task<DeleteInvoiceDto> Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
            {
                var invoiceToBeDeleted = await _invoiceRepository.GetAsync(i => i.Id == request.Id);
                if (invoiceToBeDeleted is null)
                    throw new BusinessException("Böyle bir fatura bulunamadı!");

                Invoice mappedInvoice = _mapper.Map<Invoice>(request);
                var deletedInvoice = _invoiceRepository.DeleteAsync(mappedInvoice);
                DeleteInvoiceDto deleteInvoiceDto = _mapper.Map<DeleteInvoiceDto>(deletedInvoice);
                return deleteInvoiceDto;
            }
        }
    }
}
