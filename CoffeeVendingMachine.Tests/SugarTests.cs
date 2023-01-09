using CoffeeVendingMachine.Decorators.Characteristic;
using CoffeeVendingMachine.Decorators.CoffeeTypes;
using CoffeeVendingMachine.Models;
using CoffeeVendingMachine.Shared.Interfaces;
using Moq;
using Xunit;

namespace CoffeeVendingMachine.Tests
{

    public class SugarTests
    {
        [Fact]
        public void Sugar_GetDescription()
        {
            // arrange
            var coffeeMock = new Coffee();
            var sugarMock = new Sugar(coffeeMock);
           
            // act
            var actual = sugarMock.GetDescription();

            // assert
            Assert.Equal("Basic Coffee, single pack of sugar", actual);
        }
    }

}
