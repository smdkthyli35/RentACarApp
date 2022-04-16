using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Rentals.Dtos
{
    public class DeleteRentalDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
    }
}
