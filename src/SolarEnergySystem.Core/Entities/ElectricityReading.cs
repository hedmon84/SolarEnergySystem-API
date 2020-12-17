using System;
using System.Collections.Generic;
using System.Text;

namespace SolarEnergySystem.Core.Entities
{
    public class ElectricityReading : BaseEntity<int>
    {
        public string PanelId { get; set; }

        public Panel Panel { get; set; }

        public double KiloWatt { get; set; }

        public DateTime ReadingDateTime { get; set; }
    }
}
