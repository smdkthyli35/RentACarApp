using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Rentals.Rules
{
    public class RentalBusinessRules
    {
        private readonly IRentalRepository _rentalRepository;

        public RentalBusinessRules(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        public async Task RentalCanNotBeUpdateWhenThereIsARentedCarInDate(int id, int carId, DateTime startDate,
                                                                    DateTime endDate)
        {
            IPaginate<Rental> rentals = await _rentalRepository.GetListAsync(
                                            r => r.Id != id && r.CarId == carId &&
                                                 r.EndDate >= startDate &&
                                                 r.StartDate <= endDate);
            if (rentals.Items.Any())
            {
                throw new BusinessException("Kiralamaya çalıştığınız araba için bu tarihte başka bir kiralama olduğu için kiralama güncellenemez.");
            }
        }
    }
}
