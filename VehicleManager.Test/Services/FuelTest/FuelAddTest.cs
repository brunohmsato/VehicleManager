using Moq;
using VehicleManager.Application.Services;
using VehicleManager.Domain.Interfaces;
using VehicleManager.Domain.Models;
using VehicleManager.Infra.Data.DbContext;

namespace VehicleManager.Test.Services.FuelTest
{
	public class FuelAddTest
	{
		[Fact]
		public void Add_ValidFuel_CallsFuelRepositoryAdd()
		{
			// Arrange
			var fuel = new Fuel { Id = 1, Description = "Gasoline", Status = true };
			var fuelRepositoryMock = new Mock<IFuelRepository>();
			var contextMock = new Mock<ApplicationDbContext>();
			var fuelService = new FuelService(fuelRepositoryMock.Object);

			// Act
			fuelService.Add(fuel);

			// Assert
			fuelRepositoryMock.Verify(repo => repo.Add(fuel), Times.Once);
		}
	}
}
