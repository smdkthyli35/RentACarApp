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
    public class ModelMap : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();
            builder.Property(m => m.Name).HasMaxLength(50);
            builder.Property(m => m.Name).IsRequired();
            builder.Property(m => m.DailyPrice).IsRequired();
            builder.Property(m => m.ImageUrl).HasMaxLength(250);
            builder.Property(m => m.ImageUrl).IsRequired();
            builder.HasMany(m => m.Cars);
            builder.HasOne<Transmission>(m => m.Transmission).WithMany(t => t.Models).HasForeignKey(m => m.TransmissionId);
            builder.HasOne<Fuel>(m => m.Fuel).WithMany(f => f.Models).HasForeignKey(m => m.FuelId);
            builder.HasOne<Brand>(m => m.Brand).WithMany(b => b.Models).HasForeignKey(m => m.BrandId);
            builder.ToTable("Models");
        }
    }
}
