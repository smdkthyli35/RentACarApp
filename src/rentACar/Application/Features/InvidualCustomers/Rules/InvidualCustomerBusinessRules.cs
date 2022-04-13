using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.InvidualCustomers.Rules
{
    public class InvidualCustomerBusinessRules
    {
        private readonly IInvidualCustomerRepository _invidualCustomerRepository;

        public InvidualCustomerBusinessRules(IInvidualCustomerRepository invidualCustomerRepository)
        {
            _invidualCustomerRepository = invidualCustomerRepository;
        }

        public async Task NationalIdentityCanBotBeDublicated(string nationalIdentity)
        {
            var result = await _invidualCustomerRepository.GetListAsync(i => i.NationalIdentity == nationalIdentity);
            if (result.Items.Any())
            {
                throw new BusinessException("Bu kimnlik numarası daha önceden eklenmiş. Lütfen farklı bir kimnlik numarası giriniz.");
            }
        }
    }
}
