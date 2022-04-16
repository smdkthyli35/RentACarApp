using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Invoices.Dtos
{
    public class CreateInvoiceDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime RentalStartDate { get; set; }
        public DateTime RentalEndDate { get; set; }
        public float RentalDayCount { get; set; }
        public decimal TotalRentalPrice { get; set; }
    }
}
