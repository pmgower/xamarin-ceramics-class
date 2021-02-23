using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCreationAndConsumptionApps.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiCreationAndConsumptionApps.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MonkeysController : ControllerBase
    {
        private readonly ILogger<MonkeysController> _logger;

        public MonkeysController(ILogger<MonkeysController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Monkey> Get()
        {
            return Monkey.DefaultMonkeyList.ToArray();
        }
    }
}