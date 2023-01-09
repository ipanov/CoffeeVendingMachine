using CoffeeVendingMachine.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using StarbucksApi.Controllers;
using StarbucksApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace StarbucksApi.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async Task Get_OkAsync()
        {
            // Arrange
            var serviceMock = new Mock<IStarbucksCoffeesService>();
            var result = new List<ThirdPartyCoffee> { new ThirdPartyCoffee { Type = "type", Characteristics = new List<string> { "char1", "char2" } } };
            serviceMock.Setup(m => m.GetCoffees()).ReturnsAsync(result);

            var loggerMock = new Mock<ILogger<StarbucksCoffeesController>>();

            var controller = new StarbucksCoffeesController(loggerMock.Object, serviceMock.Object);

            // Act
            var response = await controller.Get();

            // Assert
            Assert.IsType<OkObjectResult>(response.Result);
           
        }
    }
}
