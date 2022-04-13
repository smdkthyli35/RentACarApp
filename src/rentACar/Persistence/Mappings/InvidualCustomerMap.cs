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
    public class InvidualCustomerMap : IEntityTypeConfiguration<InvidualCustomer>
    {
        public void Configure(EntityTypeBuilder<InvidualCustomer> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd();
            builder.Property(i => i.Email).HasMaxLength(100).IsRequired();
            builder.Property(i => i.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(i => i.LastName).HasMaxLength(50).IsRequired();
            builder.Property(i => i.NationalIdentity).HasMaxLength(11).IsRequired();
        }
    }
}
