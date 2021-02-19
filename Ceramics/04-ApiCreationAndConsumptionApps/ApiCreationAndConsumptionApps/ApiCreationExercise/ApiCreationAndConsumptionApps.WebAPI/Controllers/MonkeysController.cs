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
        private static readonly List<Monkey> Monkeys = new List<Monkey>()
        {
            new Monkey()
            {
                Name = "Edgar",
                Description = "He has red fur and a white tail",
                // https://source.unsplash.com/250x250/?monkey
                ImageUrl = "https://via.placeholder.com/150"
            },
            new Monkey()
            {
                Name = "Sam",
                Description = "She has black fur and a orange tail",
                ImageUrl = "https://via.placeholder.com/150"
            },
            new Monkey()
            {
                Name = "Johnny",
                Description = "He has orange fur and a black tail",
                ImageUrl = "https://via.placeholder.com/150"
            },
            new Monkey()
            {
                Name = "Kevin",
                Description = "He has brown fur and a black tail",
                ImageUrl = "https://via.placeholder.com/150"
            },
            
        };

        private readonly ILogger<MonkeysController> _logger;

        public MonkeysController(ILogger<MonkeysController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Monkey> Get()
        {
            return Monkeys.ToArray();
        }
    }
}