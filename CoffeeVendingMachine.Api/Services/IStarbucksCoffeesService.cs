using CoffeeVendingMachine.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarbucksApi.Services
{
    public interface IStarbucksCoffeesService
    {
        public Task<IEnumerable<ThirdPartyCoffee>> GetCoffees();
    }
}
