using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolarEnergySystem.Core.Entities;

namespace SolarEnergySystem.Infrastructure.Configurations
{
    public class PanelConfiguration : IEntityTypeConfiguration<Panel>
    {
        public void Configure(EntityTypeBuilder<Panel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.ElectricityReadings)
                .WithOne(x => x.Panel)
                .HasForeignKey(x => x.PanelId);

            builder.Property(x => x.Latitude).IsRequired();
            builder.Property(x => x.Longitude).IsRequired();
            builder.Property(x => x.MeasuringUnit).IsRequired();
            builder.Property(x => x.PanelType).IsRequired();
        }
    }
}
