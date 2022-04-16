using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Rentals.Dtos
{
    public class RentalDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string RentedCity { get; set; }
        public string DeliveryCity { get; set; }
        public int RentStartKilometer { get; set; }
        public int? RentEndKilometer { get; set; }
    }
}
