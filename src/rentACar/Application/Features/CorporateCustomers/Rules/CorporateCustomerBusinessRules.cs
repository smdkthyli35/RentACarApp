using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CorporateCustomers.Rules
{
    public class CorporateCustomerBusinessRules
    {
        private readonly ICorporateCustomerRepository _corporateCustomerRepository;

        public CorporateCustomerBusinessRules(ICorporateCustomerRepository corporateCustomerRepository)
        {
            _corporateCustomerRepository = corporateCustomerRepository;
        }
        
        public async Task CompanyNameCanNotBeDuplicatedWhenInserted(string companyName)
        {
            var result = await _corporateCustomerRepository.GetListAsync(c => c.CompanyName == companyName);
            if (result.Items.Any())
            {
                throw new BusinessException("Bu şirket adı daha önceden eklenmiş. Lütfen farklı bir şirket adı giriniz.");
            }
        }

        public async Task TaxNumberCanNotBeDuplicatedWhenInserted(string taxNumber)
        {
            var result = await _corporateCustomerRepository.GetListAsync(c => c.TaxNumber == taxNumber);
            if (result.Items.Any())
            {
                throw new BusinessException("Bu vergi numarası daha önceden eklenmiş. Lütfen farklı bir  vergi numarası giriniz.");
            }
        }
    }
}
