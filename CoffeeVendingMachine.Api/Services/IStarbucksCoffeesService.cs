using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarbucksCoffee.Api.Services
{
    public interface IStarbucksCoffeesService
    {
        public Task<IEnumerable<Models.StarbucksCoffee>> GetCoffees();
    }
}
