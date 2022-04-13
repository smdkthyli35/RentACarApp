﻿using Application.Features.Customers.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CorporateCustomers.Models
{
    public class CorporateCustomerListModel
    {
        public IList<CorporateCustomerListDto> Items { get; set; }
    }
}
