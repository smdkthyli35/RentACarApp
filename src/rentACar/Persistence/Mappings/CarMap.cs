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
    public class CarMap : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Plate).HasMaxLength(20);
            builder.Property(c => c.Plate).IsRequired();
            builder.Property(c => c.ModelYear).IsRequired();
            builder.HasOne<Color>(c => c.Color).WithMany(c => c.Cars).HasForeignKey(c => c.ColorId);
            builder.HasOne<Model>(c => c.Model).WithMany(m => m.Cars).HasForeignKey(c => c.ModelId);
            builder.HasOne<City>(c => c.City).WithMany(c => c.Cars).HasForeignKey(c => c.CityId);
            builder.ToTable("Cars");
        }
    }
}
