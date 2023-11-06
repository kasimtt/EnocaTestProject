using EnocaTestProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaTestProject.Persistence.EntityConfigurations
{
    public class CarrierConfiguration : IEntityTypeConfiguration<Carrier>
    {
        public void Configure(EntityTypeBuilder<Carrier> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c=>c.CarrierName).IsRequired().HasMaxLength(64);
            builder.Property(c=>c.CarrierPlusDesiCost).IsRequired();
            builder.Property(c=>c.CarrierIsActive).IsRequired();
            builder.HasOne(c => c.CarrierConfiguration).WithOne(cc => cc.Carrier);
            builder.HasMany(c=>c.Orders).WithOne(o=>o.Carrier).HasForeignKey(o=>o.CarrierId).IsRequired();
            builder.HasMany(c => c.CarrierReports).WithOne(c => c.Carrier).HasForeignKey(c => c.CarrierId);

            
        }
    }
}
