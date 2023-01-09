using CoffeeVendingMachine.Decorators.CoffeeTypes;
using CoffeeVendingMachine.Decorators.CoffeeTypes.Factories;
using Xunit;

namespace CoffeeVendingMachine.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void CreateCoffee_CreatesEspresso()
        {
            /// Arrange
            var type = "Latte";

            //Act
            var result = CoffeeFactory.CreateCoffee(type);

            //Assert
            Assert.IsType<Espresso>(result);
        }

        [Fact]
        public void CreateCoffee_CreatesCustomCoffee()
        {

        }


        [Fact]
        public void CreateCoffee_ThrowsException()
        {

        }

    }
}
