using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

using System.Collections.Generic;
using ZooVentureAPI.Controllers;
using ZooVentureAPI.Models;
using ZooVentureAPI.Services;
using ZooVentureAPI.DTO; // Make sure to include the namespace for FoodExpenseResultDTO

namespace Tests
{
    [TestFixture]
    public class ZooControllerTests
    {
        private ZooController _zooController;
        private Mock<IFoodServices> _foodServiceMock;
        private Mock<IFileServices> _fileServiceMock;
        private Mock<IConfiguration> _configurationMock;
        private Mock<ILogger<ZooController>> _loggerMock;

        [SetUp]
        public void Setup()
        {
            _foodServiceMock = new Mock<IFoodServices>();
            _fileServiceMock = new Mock<IFileServices>();
            _configurationMock = new Mock<IConfiguration>();
            _loggerMock = new Mock<ILogger<ZooController>>();

            _zooController = new ZooController(
                _foodServiceMock.Object,
                _fileServiceMock.Object,
                _configurationMock.Object,
                _loggerMock.Object
            );
        }

        [Test]
        public void CalculateFoodExpenses_Success()
        {
            // Arrange
            _configurationMock.Setup(c => c["AppSettings:ZooFilePath"]).Returns("zoo.txt");
            _configurationMock.Setup(c => c["AppSettings:AnimalsFilePath"]).Returns("animals.txt");
            _configurationMock.Setup(c => c["AppSettings:PricesFilePath"]).Returns("prices.txt");

            // Mock file service methods
            _fileServiceMock.Setup(fs => fs.ReadZoo("zoo.txt")).Returns(new Zoo());
            _fileServiceMock.Setup(fs => fs.ReadAnimals("animals.txt")).Returns(new List<Animals>());
            _fileServiceMock.Setup(fs => fs.ReadFoodPrices("prices.txt")).Returns(new List<FoodPrice>());

            // Mock food service method with a list of FoodExpenseResultDTO
            var mockedFoodExpenseResultList = new List<FoodExpenseResultDTO>
            {
                new FoodExpenseResultDTO { SlNo = 1, Name = "Food1", Animal = "Lion", AnimalSpecies = "Big Cat", Weight = 100, TotalFoodCost = 150.50M },
                new FoodExpenseResultDTO { SlNo = 2, Name = "Food2", Animal = "Elephant", AnimalSpecies = "Mammal", Weight = 500, TotalFoodCost = 300.75M },
                // Add more items as needed
            };

            _foodServiceMock.Setup(fs => fs.AddResultsForAnimalType(It.IsAny<Zoo>(), It.IsAny<List<Animals>>(), It.IsAny<List<FoodPrice>>()))
                .Returns(mockedFoodExpenseResultList);

            // Act
            var result = _zooController.CalculateFoodExpenses() as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(mockedFoodExpenseResultList, result.Value);
        }

        // Add more test cases for error scenarios, if necessary
    }
}
