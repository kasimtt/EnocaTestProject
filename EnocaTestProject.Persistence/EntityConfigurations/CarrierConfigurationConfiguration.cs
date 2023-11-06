using EnocaTestProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using c = EnocaTestProject.Domain.Entities;

namespace EnocaTestProject.Persistence.EntityConfigurations
{
    public class CarrierConfigurationConfiguration : IEntityTypeConfiguration<c.CarrierConfiguration>
    {
        public void Configure(EntityTypeBuilder<c.CarrierConfiguration> builder)
        {
            builder.HasKey(cc => cc.Id);
            builder.Property(cc => cc.CarrierMaxDesi).IsRequired();
            builder.Property(cc=>cc.CarrierMinDesi).IsRequired();
            builder.Property(cc=>cc.CarrierCost).IsRequired();
            builder.HasOne(cc => cc.Carrier).WithOne(c => c.CarrierConfiguration).HasForeignKey<c.CarrierConfiguration>(c => c.CarrierId).IsRequired(false);
            
        }
    }
}
