using System;
using SolarEnergySystem.Core.Entities;

namespace SolarEnergySystem.Core
{
    public class ReadingFactory
    {
        ElectricityReading Create(string panelId, double quantity)
        {
            return new ElectricityReading
            {
                PanelId = panelId,
                KiloWatt = quantity,
                ReadingDateTime = DateTime.UtcNow,
            };
        }
    }
}