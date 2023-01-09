using CoffeeVendingMachine.Decorators.CoffeeTypes;
using CoffeeVendingMachine.Factories;
using Xunit;

namespace CoffeeVendingMachine.Tests
{
    public class CoffeeFactoryTests
    {
        [Fact]
        public void CreateCoffee_CreatesEspresso()
        {
            /// Arrange
            var type = "Espresso";

            //Act
            var result = CoffeeFactory.CreateCoffee(type);

            //Assert
            Assert.IsType<Espresso>(result);
        }
    }
}
