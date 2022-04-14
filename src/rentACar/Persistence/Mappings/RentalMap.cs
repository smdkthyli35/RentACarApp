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
    public class RentalMap : IEntityTypeConfiguration<Rental>
    {
        public void Configure(EntityTypeBuilder<Rental> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id).ValueGeneratedOnAdd();
            builder.Property(r => r.StartDate).IsRequired();
            builder.Property(r => r.EndDate).IsRequired();
            builder.Property(r => r.EndDate).IsRequired();
            builder.Property(r => r.RentStartKilometer).IsRequired();
            builder.Property(r => r.RentedCity).HasMaxLength(50).IsRequired();
            builder.Property(r => r.DeliveryCity).HasMaxLength(50).IsRequired();
            builder.HasOne<Car>(r => r.Car).WithMany(c => c.Rentals).HasForeignKey(r => r.CarId);
            builder.HasOne<Customer>(r => r.Customer).WithMany(c => c.Rentals).HasForeignKey(r => r.CustomerId);
            builder.ToTable("Rentals");
        }
    }
}
