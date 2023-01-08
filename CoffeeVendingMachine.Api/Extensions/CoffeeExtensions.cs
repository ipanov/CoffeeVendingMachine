using CoffeeVendingMachine.Shared.Models;
using StarbucksApi.DataAccessLayer.Entities;
using System.Linq;

namespace StarbucksApi.Extensions
{
    public static class CoffeeExtensions
    {
        public static ThirdPartyCoffee ToThirdPartyCoffee(this Coffee coffee)
        {
            return new ThirdPartyCoffee
            {
                Type = coffee.Type,
                Characteristics = coffee.Characteristics.Select(c => c.Description).ToList()
            };
        }
    }
}
