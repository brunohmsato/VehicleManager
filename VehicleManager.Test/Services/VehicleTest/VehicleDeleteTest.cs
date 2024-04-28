using Moq;
using VehicleManager.Application.Services;
using VehicleManager.Domain.Interfaces;
using VehicleManager.Infra.Data.DbContext;

namespace VehicleManager.Test.Services.VehicleTest
{
	public class VehicleDeleteTest
	{
		[Fact]
		public void Delete_CallsVehicleRepositoryDelete()
		{
			// Arrange
			int idToDelete = 1;

			var vehicleRepositoryMock = new Mock<IVehicleRepository>();
			var contextMock = new Mock<ApplicationDbContext>();
			var vehicleService = new VehicleService(vehicleRepositoryMock.Object);

			// Act
			vehicleService.Delete(idToDelete);

			// Assert
			vehicleRepositoryMock.Verify(repo => repo.Delete(idToDelete), Times.Once);
		}
	}
}
