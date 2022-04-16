using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Invoices.Rules
{
    public class InvoiceBusinessRules
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceBusinessRules(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task InvoiceNoCanNotBeDuplicatedWhenInserted(string invoiceNo)
        {
            IPaginate<Invoice> result = await _invoiceRepository.GetListAsync(i => i.InvoiceNo == invoiceNo);
            if (result.Items.Any())
            {
                throw new BusinessException("Bu fatura no daha önceden eklenmiş. Lütfen farklı bir fatura no giriniz.");
            }
        }
    }
}
