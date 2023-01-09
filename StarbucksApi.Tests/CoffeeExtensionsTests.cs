using CoffeeVendingMachine.Shared.Models;
using StarbucksApi.DataAccessLayer.Entities;
using StarbucksApi.Extensions;
using Xunit;

namespace StarbucksApi.Tests
{
    public class CoffeeExtensionsTests
    {
        [Fact]
        public void  ToThirdPartyCoffee_ReturnsThirdPartyCoffee()
        {
            //arange
            var coffee = new Coffee { Id = 1, Type = "Starbucks Latte", Characteristics = { 
                          new Characteristic { Id = 1, Description = "extra cream" },
                          new Characteristic { Id = 2, Description = "brown sugar" },
                          new Characteristic { Id = 3, Description = "double shot" } 
                }};

            //act 
            var result = coffee.ToThirdPartyCoffee();

            //assert
            Assert.IsType<ThirdPartyCoffee>(result);
            Assert.Equal("Starbucks Latte", result.Type);
        }
    }
}
