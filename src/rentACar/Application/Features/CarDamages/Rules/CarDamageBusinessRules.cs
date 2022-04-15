using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CarDamages.Rules
{
    public class CarDamageBusinessRules
    {
        private readonly ICarDamageRepository _carDamageRepository;

        public CarDamageBusinessRules(ICarDamageRepository carDamageRepository)
        {
            _carDamageRepository = carDamageRepository;
        }

        public async Task CarIdCanNotBeNull(int carId)
        {
            IPaginate<CarDamage> result = await _carDamageRepository.GetListAsync(d => d.CarId == carId);
            if (result.Items.Any())
            {
                throw new BusinessException("Araba boş olamaz! Lütfen bir araba bilgisi giriniz.");
            }
        }
    }
}
