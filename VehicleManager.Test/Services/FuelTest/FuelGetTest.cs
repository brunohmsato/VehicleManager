using Moq;
using VehicleManager.Application.Services;
using VehicleManager.Domain.Interfaces;
using VehicleManager.Domain.Models;
using VehicleManager.Infra.Data.DbContext;

namespace VehicleManager.Test.Services.FuelTest
{
    public class FuelGetTest
    {
        [Fact]
        public void GetAll_CallsFuelRepositoryGetAll()
        {
            // Arrange
            var expectedFuels = new List<Fuel>
            {
                new Fuel { Id = 1, Description = "Gasoline", Status = true },
                new Fuel { Id = 2, Description = "Diesel", Status = true },
            };

            var fuelRepositoryMock = new Mock<IFuelRepository>();
            fuelRepositoryMock.Setup(repo => repo.GetAll()).Returns(expectedFuels);

            var contextMock = new Mock<ApplicationDbContext>();
            var fuelService = new FuelService(fuelRepositoryMock.Object);

            // Act
            var actualFuels = fuelService.GetAll();

            // Assert
            Assert.Equal(expectedFuels, actualFuels);
        }

        [Fact]
        public void GetById_CallsFuelRepositoryGetById()
        {
            // Arrange
            int id = 1;
            var expectedFuel = new Fuel { Id = id, Description = "Gasoline", Status = true };

            var fuelRepositoryMock = new Mock<IFuelRepository>();
            fuelRepositoryMock.Setup(repo => repo.GetById(id)).Returns(expectedFuel);

            var contextMock = new Mock<ApplicationDbContext>();
            var fuelService = new FuelService(fuelRepositoryMock.Object);

            // Act
            var actualFuel = fuelService.GetById(id);

            // Assert
            Assert.Equal(expectedFuel, actualFuel);
        }
    }
}