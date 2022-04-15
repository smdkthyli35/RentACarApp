using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cities.Rules
{
    public class CityBusinessRules
    {
        private readonly ICityRepository _cityRepository;

        public CityBusinessRules(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task CityNameCanNotBeDuplicatedWhenInserted(string name)
        {
            var result = await _cityRepository.GetListAsync(c => c.Name == name);
            if (result.Items.Any())
            {
                throw new BusinessException("Bu şehir adı daha önceden eklenmiş. Lütfen farklı bir şehir adı giriniz.");
            }
        }
    }
}
