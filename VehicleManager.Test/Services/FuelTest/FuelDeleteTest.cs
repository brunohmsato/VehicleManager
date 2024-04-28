using Moq;
using VehicleManager.Application.Services;
using VehicleManager.Domain.Interfaces;
using VehicleManager.Infra.Data.DbContext;

namespace VehicleManager.Test.Services.FuelTest
{
	public class FuelDeleteTest
	{
		[Fact]
		public void Delete_CallsFuelRepositoryDelete()
		{
			// Arrange
			int idToDelete = 1;

			var fuelRepositoryMock = new Mock<IFuelRepository>();
			var contextMock = new Mock<ApplicationDbContext>();
			var fuelService = new FuelService(fuelRepositoryMock.Object);

			// Act
			fuelService.Delete(idToDelete);

			// Assert
			fuelRepositoryMock.Verify(repo => repo.Delete(idToDelete), Times.Once);
		}
	}
}
