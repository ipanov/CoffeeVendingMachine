using StarbucksCoffee.Api.DataAccessLayer;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using StarbucksCoffee.Api.Extensions;

namespace StarbucksCoffee.Api.Services
{
    public class StarbucksCoffeeService : IStarbucksCoffeesService
    {
        private readonly StarbucksCoffeeDbContext _context;
        private readonly ILogger<StarbucksCoffeeService> _logger;

        public StarbucksCoffeeService(StarbucksCoffeeDbContext context, ILogger<StarbucksCoffeeService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IEnumerable<Models.StarbucksCoffee>> GetCoffees()
        {
            var cofeees = await _context.Coffeees.ToListAsync();
            return cofeees.Select(r => r.ToStarbucksCoffee());
        }
    }
}
