using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Mappings
{
    public class CorporateCustomerMap : IEntityTypeConfiguration<CorporateCustomer>
    {
        public void Configure(EntityTypeBuilder<CorporateCustomer> builder)
        {
            builder.Property(c => c.CompanyName).HasMaxLength(100).IsRequired();
            builder.Property(c => c.TaxNumber).HasMaxLength(50).IsRequired();
            builder.ToTable("CorporateCustomers");
        }
    }
}
