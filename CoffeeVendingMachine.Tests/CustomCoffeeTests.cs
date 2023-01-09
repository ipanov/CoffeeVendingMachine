using CoffeeVendingMachine.Decorators.Characteristic;
using CoffeeVendingMachine.Decorators.CoffeeTypes;
using CoffeeVendingMachine.Models;
using Xunit;

namespace CoffeeVendingMachine.Tests
{
    public class CustomCoffeeTests
    {

        [Fact]
        public void CustomCoffee_GetDescription()
        {
            // arrange
            var coffeeMock = new Coffee();
            var espresso = new Espresso(coffeeMock);
            var customCoffee = new CustomCoffee(espresso, "custom");
            var creamer = new Creamer(customCoffee);

            // act
            var actual = creamer.GetDescription();

            // assert
            Assert.Equal("custom Espresso, one pack of sugar, with creamer", actual);
        }
    }
}
