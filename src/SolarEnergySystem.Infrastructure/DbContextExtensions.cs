using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SolarEnergySystem.Core.Entities;
using SolarEnergySystem.Core.Enums;

namespace SolarEnergySystem.Infrastructure
{
    public static class DbContextExtensions
    {
        public static void SeedData(this SolarEnergySystemDatabaseContext context)
        {
            context.AddRange(new List<Panel>
            {
                new Panel
                {
                    Brand = "Brand1",
                    Latitude = -3850.04,
                    Longitude = 450.93,
                    MeasuringUnit = MeasuringUnit.KiloWatt,
                    PanelType = PanelType.Regular,
                    Id = "A305V5",
                    ElectricityReadings = new List<ElectricityReading>
                    {
                        new ElectricityReading
                        {
                            KiloWatt = 560,
                            ReadingDateTime = DateTime.UtcNow
                        },
                        new ElectricityReading
                        {
                            KiloWatt = 609,
                            ReadingDateTime = DateTime.UtcNow.AddHours(-1)
                        },
                        new ElectricityReading
                        {
                            KiloWatt = 560,
                            ReadingDateTime = DateTime.UtcNow.AddHours(-2)
                        }
                    }
                },
                new Panel
                {
                    Brand = "Brand2",
                    Latitude = -3867.04,
                    Longitude = -4607.92,
                    MeasuringUnit = MeasuringUnit.Watt,
                    PanelType = PanelType.Limited,
                    Id = "BU492K",
                    ElectricityReadings = new List<ElectricityReading>
                    {
                        new ElectricityReading
                        {
                            KiloWatt = 6707,
                            ReadingDateTime = DateTime.UtcNow
                        },
                        new ElectricityReading
                        {
                            KiloWatt = 5670,
                            ReadingDateTime = DateTime.UtcNow.AddDays(-1)
                        },
                        new ElectricityReading
                        {
                            KiloWatt = 2450,
                            ReadingDateTime = DateTime.UtcNow.AddDays(-2)
                        }
                    }
                },
                new Panel
                {
                    Brand = "Brand3",
                    Latitude = 578.0,
                    Longitude = -245.5,
                    MeasuringUnit = MeasuringUnit.Watt,
                    PanelType = PanelType.Ultimate,
                    Id = "CFJ39R",
                    ElectricityReadings = new List<ElectricityReading>
                    {
                        new ElectricityReading
                        {
                            KiloWatt = 6707,
                            ReadingDateTime = DateTime.UtcNow
                        },
                        new ElectricityReading
                        {
                            KiloWatt = 5670,
                            ReadingDateTime = DateTime.UtcNow.AddMinutes(-1)
                        },
                        new ElectricityReading
                        {
                            KiloWatt = 2450,
                            ReadingDateTime = DateTime.UtcNow.AddMinutes(-2)
                        }
                    }
                }
            });

            context.SaveChanges();
        }
    }
}
