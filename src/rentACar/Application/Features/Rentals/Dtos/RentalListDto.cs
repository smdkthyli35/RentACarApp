using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Rentals.Dtos
{
    public class RentalListDto
    {
        public int Id { get; set; }
        public string CarModelBrandName { get; set; }
        public string CarModelName { get; set; }
        public string CarColorName { get; set; }
        public short CarModelYear { get; set; }
        public string CarPlate { get; set; }
        public string CustomerFullName { get; set; }
        public string CustomerMail { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
