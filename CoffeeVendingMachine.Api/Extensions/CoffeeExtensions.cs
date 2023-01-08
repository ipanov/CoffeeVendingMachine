using StarbucksCoffee.Api.DataAccessLayer.Entities;
using System.Linq;

namespace StarbucksCoffee.Api.Extensions
{
    public static class MyExtensions
    {
        public static Models.StarbucksCoffee ToStarbucksCoffee(this Coffee coffee)
        {
            return new Models.StarbucksCoffee
            {
                Type = coffee.Type,
                Characteristics = coffee.Characteristics.Select(c => c.Description).ToList()
            };
        }
    }
}
