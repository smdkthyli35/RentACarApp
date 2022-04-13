using Application.Features.InvidualCustomers.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.InvidualCustomers.Models
{
    public class InvidualCustomerListModel
    {
        public IList<InvidualCustomerListDto> Items { get; set; }
    }
}
