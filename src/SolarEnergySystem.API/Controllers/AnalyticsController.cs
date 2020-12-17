using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SolarEnergySystem.API.Models;
using SolarEnergySystem.Core.Entities;
using SolarEnergySystem.Core.Enums;
using SolarEnergySystem.Core.Interfaces;
using SolarEnergySystem.Infrastructure;

namespace SolarEnergySystem.API.Controllers
{
    [ApiController]
    [Route("panels")]
    public class AnalyticsController : ControllerBase
    {
        private readonly IRepository<ElectricityReading, int> _analyticRepository;
        private readonly IRepository<Panel, string> _panelRepository;
        private readonly SolarEnergySystemDatabaseContext _context;

        public AnalyticsController(IRepository<ElectricityReading, int> analyticRepository,
            IRepository<Panel, string> panelRepository, SolarEnergySystemDatabaseContext context)
        {
            _analyticRepository = analyticRepository;
            _panelRepository = panelRepository;
            _context = context;
        }

        [Route("{panelId}/analytics")]
        public IActionResult Get(string panelId)
        {
            return Ok(_panelRepository.GetAll());
        }

        [HttpGet("{panelId}/report")]
        public IActionResult GetReport(string panelId)
        {
            var panel = _context.Panel.FirstOrDefault(x => x.Id == panelId);

            var measurements = panel?.ElectricityReadings;

            if (measurements == null)
            {
                return Ok(new ReportDto
                {
                    Average = 0,
                    Sum = 0,
                    Max = 0,
                    Min = 0
                });
            }

            return Ok(new ReportDto
            {
                Average = measurements.Average(x => x.KiloWatt),
                Sum = measurements.Sum(x => x.KiloWatt),
                Max = measurements.Max(x => x.KiloWatt),
                Min = measurements.Min(x => x.KiloWatt)
            });
        }

        [HttpPost("{panelId}/analytics")]
        public ActionResult Post(string panelId, [FromBody] AnalyticDto analytic)
        {
            if (analytic.Measurement <= 0)
            {
                return BadRequest("valor incorrecto");
            }

            var panel = _panelRepository.GetById(panelId);

            var lastMeasurement = panel.ElectricityReadings.ToList().OrderBy(p => p.ReadingDateTime).LastOrDefault();

            if (lastMeasurement != null && ValidateTimeLimits(lastMeasurement, panel.PanelType))
            {
                return BadRequest("Mediciones no permitidas en el intervalo de tiempo actual");
            }

            var measurement = analytic.Measurement;

            var analyticData = new ElectricityReading
            {
                ReadingDateTime = DateTime.UtcNow,
                Panel = panel,
                KiloWatt = panel.MeasuringUnit == MeasuringUnit.Watt ? measurement / 1000 : measurement,
            };

            _analyticRepository.Add(analyticData);

            return Ok();
        }

        public bool ValidateTimeLimits(ElectricityReading electricityReading, PanelType panelType)
        {
            switch (panelType)
            {
                case PanelType.Regular when DateTime.UtcNow.Subtract(electricityReading.ReadingDateTime).Hours >= 1:
                case PanelType.Limited when DateTime.UtcNow.Subtract(electricityReading.ReadingDateTime).Days >= 1 &&
                                            electricityReading.KiloWatt < 5:
                case PanelType.Ultimate
                    when DateTime.UtcNow.Subtract(electricityReading.ReadingDateTime).Minutes >= 1 &&
                         electricityReading.KiloWatt >= 5:
                    return true;
                default:
                    return false;
            }
        }
    }
}