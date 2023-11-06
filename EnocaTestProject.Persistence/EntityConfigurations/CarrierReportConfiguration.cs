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
    public class CarrierReportConfiguration : IEntityTypeConfiguration<CarrierReport>
    {
        public void Configure(EntityTypeBuilder<CarrierReport> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c=>c.CarrierReportDate).IsRequired();
            builder.Property(c=>c.CarrierCost).IsRequired();
            builder.HasOne(c => c.Carrier).WithMany(c => c.CarrierReports).HasForeignKey(c => c.CarrierId);
        }
    }
}
