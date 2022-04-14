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
    public class RentalAdditionalServiceMap : IEntityTypeConfiguration<RentalAdditionalService>
    {
        public void Configure(EntityTypeBuilder<RentalAdditionalService> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id).ValueGeneratedOnAdd();
            builder.HasOne<Rental>(r => r.Rental).WithMany(r => r.RentalAdditionalServices).HasForeignKey(r => r.RentalId);
            builder.HasOne<AdditionalService>(r => r.AdditionalService).WithMany(a => a.RentalAdditionalServices).HasForeignKey(r => r.AdditionalServiceId);
            builder.ToTable("RentalAdditionalServices");
        }
    }
}
