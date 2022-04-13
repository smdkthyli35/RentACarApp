using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.IndividualCustomers.Rules
{
    public class IndividualCustomerBusinessRules
    {
        private readonly IIndividualCustomerRepository _individualCustomerRepository;

        public IndividualCustomerBusinessRules(IIndividualCustomerRepository individualCustomerRepository)
        {
            _individualCustomerRepository = individualCustomerRepository;
        }

        public async Task NationalIdentityCanBotBeDublicated(string nationalIdentity)
        {
            var result = await _individualCustomerRepository.GetListAsync(i => i.NationalIdentity == nationalIdentity);
            if (result.Items.Any())
            {
                throw new BusinessException("Bu kimnlik numarası daha önceden eklenmiş. Lütfen farklı bir kimnlik numarası giriniz.");
            }
        }
    }
}
