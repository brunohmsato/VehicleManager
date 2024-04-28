using Moq;
using VehicleManager.Application.Services;
using VehicleManager.Domain.Interfaces;
using VehicleManager.Domain.Models;
using VehicleManager.Infra.Data.DbContext;

namespace VehicleManager.Test.Services.FuelTest
{
    public class FuelUpdateTest
    {
        [Fact]
        public void Update_CallsFuelRepositoryUpdate()
        {
            // Arrange
            var fuelToUpdate = new Fuel { Id = 1, Description = "Gasoline", Status = true };

            var fuelRepositoryMock = new Mock<IFuelRepository>();
            var contextMock = new Mock<ApplicationDbContext>();
            var fuelService = new FuelService(fuelRepositoryMock.Object);

            // Act

            fuelService.Update(fuelToUpdate);

            // Assert
            fuelRepositoryMock.Verify(repo => repo.Update(fuelToUpdate), Times.Once);
        }
    }
}