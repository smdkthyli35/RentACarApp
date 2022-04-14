using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Rental : Entity
    {
        public Rental()
        {
            RentalAdditionalServices = new HashSet<RentalAdditionalService>();
        }

        public Rental(int id, int carId, int customerId, DateTime startDate, DateTime endDate, DateTime? returnDate, string rentedCity, string deliveryCity, int rentStartKilometer, int? rentEndKilometer) : this()
        {
            Id = id;
            CarId = carId;
            CustomerId = customerId;
            StartDate = startDate;
            EndDate = endDate;
            ReturnDate = returnDate;
            RentedCity = rentedCity;
            DeliveryCity = deliveryCity;
            RentStartKilometer = rentStartKilometer;
            RentEndKilometer = rentEndKilometer;
        }

        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string RentedCity { get; set; }
        public string DeliveryCity { get; set; }
        public int RentStartKilometer { get; set; }
        public int? RentEndKilometer { get; set; }

        public virtual Car Car { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual ICollection<RentalAdditionalService> RentalAdditionalServices { get; set; }
    }
}
