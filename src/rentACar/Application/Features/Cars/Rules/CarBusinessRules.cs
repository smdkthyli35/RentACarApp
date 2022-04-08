using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Rules
{
    public class CarBusinessRules
    {
        private readonly ICarRepository _carRepository;

        public CarBusinessRules(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task PlateCanNotBeDuplicatedInsertedAndUpdated(string plate)
        {
            var result = await _carRepository.GetListAsync(c => c.Plate == plate);
            if (result.Items.Any())
            {
                throw new BusinessException("Bu isimde bir araba adı bulumadı!");
            }
        }

        public async Task CarCanNotRentWhenIsInMaintenance(int id)
        {
            var carToRent = await _carRepository.GetAsync(c => c.Id == id);
            if (carToRent.CarState == CarState.Maintenance)
            {
                throw new BusinessException("Üzgünüz, araç bakımda olduğu için şu an kiralanmasına izin veremiyoruz.");
            }
        }

        public async Task CarCanNotBeMaintenanceWhenCarIsRented(int id)
        {
            var carToMaintenance = await _carRepository.GetAsync(c => c.Id == id);
            if (carToMaintenance.CarState == CarState.Maintenance)
            {
                throw new BusinessException("Üzgünüz, araç kiralandığı için bakım yapılamamaktadır.");
            }
        }

        public async Task IsExists(int id)
        {
            var car = await _carRepository.GetAsync(c => c.Id == id);
            if (car is null)
            {
                throw new BusinessException("Böyle bir araba bulunmamaktadır.");
            }
        }

        public Task CarCannotBeNull(Car car)
        {
            if (car == null)
                throw new BusinessException("Araba boş olamaz!");

            return Task.CompletedTask;
        }

        public Task CarMustNotBeAvailable(Car car)
        {
            if (car.CarState == CarState.Available)
                throw new BusinessException("Böyle bir araba zaten mevcut!");

            return Task.CompletedTask;
        }
    }
}
