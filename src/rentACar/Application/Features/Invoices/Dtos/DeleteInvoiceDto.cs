using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Invoices.Dtos
{
    public class DeleteInvoiceDto
    {
        public int Id { get; set; }
        public string InvoiceNo { get; set; }
    }
}
