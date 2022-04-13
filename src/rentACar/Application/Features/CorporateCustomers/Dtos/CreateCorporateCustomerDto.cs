using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Dtos
{
    public class CreateCorporateCustomerDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }
    }
}
