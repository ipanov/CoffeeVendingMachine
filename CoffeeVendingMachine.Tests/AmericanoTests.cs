using CoffeeVendingMachine.Decorators.CoffeeTypes;
using CoffeeVendingMachine.Models;
using Xunit;

namespace CoffeeVendingMachine.Tests
{
    public class AmericanoTests
    {
        [Fact]
        public void Americano_GetDescription()
        {
            // arrange
            var coffeeMock = new Coffee();
            var americanoMock = new Americano(coffeeMock);

            // act
            var actual = americanoMock.GetDescription();

            // assert
            Assert.Equal("Americano, Caramelle, Creamer", actual);
        }
    }
}
