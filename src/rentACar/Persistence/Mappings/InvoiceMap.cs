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
    public class InvoiceMap : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd();
            builder.Property(i => i.InvoiceNo).HasMaxLength(50).IsRequired();
            builder.Property(i => i.CreatedDate).IsRequired();
            builder.Property(i => i.RentalStartDate).IsRequired();
            builder.Property(i => i.RentalEndDate).IsRequired();
            builder.Property(i => i.RentalDayCount).IsRequired();
            builder.Property(i => i.TotalRentalPrice).IsRequired();
            builder.HasOne<Customer>(i => i.Customer).WithMany(c => c.Invoices).HasForeignKey(i => i.CustomerId);
            builder.ToTable("Invoices");
        }
    }
}
