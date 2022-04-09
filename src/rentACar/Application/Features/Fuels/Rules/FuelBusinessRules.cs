using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Fuels.Rules
{
    public class FuelBusinessRules
    {
        private readonly IFuelRepository _fuelRepository;

        public FuelBusinessRules(IFuelRepository fuelRepository)
        {
            _fuelRepository = fuelRepository;
        }

        public async Task FuelNameCanNotBeDuplicatedWhenInserted(string name)
        {
            var result = await _fuelRepository.GetListAsync(f => f.Name == name);
            if (result.Items.Any())
            {
                throw new BusinessException("Bu yakıt adı daha önceden eklenmiş. Lütfen farklı bir yakıt adı giriniz.");
            }
        }
    }
}
