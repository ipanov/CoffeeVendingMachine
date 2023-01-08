using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using StarbucksCoffee.Api.Services;

namespace StarbucksCoffee.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StarbucksCoffeesController : ControllerBase
    {
        private readonly IStarbucksCoffeesService _service;
        private readonly ILogger<StarbucksCoffeesController> _logger;

        public StarbucksCoffeesController(ILogger<StarbucksCoffeesController> logger, StarbucksCoffeeService service)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<Models.StarbucksCoffee>> Get()
        {
            var coffees = await _service.GetCoffees();
            return Ok(coffees);
        }
    }
}
