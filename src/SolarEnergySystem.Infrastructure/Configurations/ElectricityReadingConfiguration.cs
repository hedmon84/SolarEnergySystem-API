using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolarEnergySystem.Core.Entities;

namespace SolarEnergySystem.Infrastructure.Configurations
{
    public class ElectricityReadingConfiguration : IEntityTypeConfiguration<ElectricityReading>
    {
        public void Configure(EntityTypeBuilder<ElectricityReading> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.KiloWatt).IsRequired();

            builder.Property(x => x.ReadingDateTime).IsRequired();
        }
    }
}
