using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SolarEnergySystem.Core.Entities;
using SolarEnergySystem.Core.Interfaces;
using SolarEnergySystem.Infrastructure;

namespace SolarEnergySystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PanelsController : ControllerBase
    {
        private readonly IRepository<Panel, string> _panelRepository;

        public PanelsController(IRepository<Panel, string> panelRepository)
        {
            _panelRepository = panelRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_panelRepository.GetAll());
        }
        
        [HttpGet("{panelId}")]
        public IActionResult GetById(string panelId)
        {
            return Ok(_panelRepository.GetById(panelId));
        }
    }
}
