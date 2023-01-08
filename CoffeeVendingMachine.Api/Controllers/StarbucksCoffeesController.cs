using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using StarbucksApi.Services;
using CoffeeVendingMachine.Shared.Models;

namespace StarbucksApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StarbucksCoffeesController : ControllerBase
    {
        private readonly IStarbucksCoffeesService _service;
        private readonly ILogger<StarbucksCoffeesController> _logger;

        public StarbucksCoffeesController(ILogger<StarbucksCoffeesController> logger, IStarbucksCoffeesService service)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<ThirdPartyCoffee>> Get()
        {
            var coffees = await _service.GetCoffees();
            return Ok(coffees);
        }
    }
}
