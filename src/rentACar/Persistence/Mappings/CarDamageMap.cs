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
    public class CarDamageMap : IEntityTypeConfiguration<CarDamage>
    {
        public void Configure(EntityTypeBuilder<CarDamage> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.DamageDetail).HasMaxLength(500).IsRequired();
            builder.HasOne<Car>(c => c.Car).WithMany(c => c.CarDamages).HasForeignKey(c => c.CarId);
            builder.ToTable("CarDamages");
        }
    }
}
