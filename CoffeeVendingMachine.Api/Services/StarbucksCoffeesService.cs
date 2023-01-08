using StarbucksApi.DataAccessLayer;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

using CoffeeVendingMachine.Shared.Models;
using StarbucksApi.Extensions;

namespace StarbucksApi.Services
{
    public class StarbucksCoffeesService : IStarbucksCoffeesService
    {
        private readonly StarbucksCoffeeDbContext _context;
        private readonly ILogger<StarbucksCoffeesService> _logger;

        public StarbucksCoffeesService(StarbucksCoffeeDbContext context, ILogger<StarbucksCoffeesService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IEnumerable<ThirdPartyCoffee>> GetCoffees()
        {
            var coffees = await _context.Coffeees.Include(c => c.Characteristics).ToListAsync();
            return coffees.Select(r => r.ToThirdPartyCoffee());
        }
    }
}
