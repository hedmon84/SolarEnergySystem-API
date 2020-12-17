using System;
using Microsoft.EntityFrameworkCore;
using SolarEnergySystem.Core.Entities;
using SolarEnergySystem.Infrastructure.Configurations;

namespace SolarEnergySystem.Infrastructure
{
    public class SolarEnergySystemDatabaseContext : DbContext
    {
        public SolarEnergySystemDatabaseContext(DbContextOptions dbContextOptions)
            :base(dbContextOptions)
        {
            
        }

        public DbSet<Panel> Panel { get; set; }

        public DbSet<ElectricityReading> ElectricityReading { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PanelConfiguration());
            modelBuilder.ApplyConfiguration(new ElectricityReadingConfiguration());
        }
    }
}
