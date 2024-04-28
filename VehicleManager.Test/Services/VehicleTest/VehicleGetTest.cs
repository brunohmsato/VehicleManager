using Moq;
using VehicleManager.Application.Services;
using VehicleManager.Domain.Interfaces;
using VehicleManager.Domain.Models;
using VehicleManager.Infra.Data.DbContext;

namespace VehicleManager.Test.Services.VehicleTest
{
	public class VehicleGetTest
	{
		[Fact]
		public void GetAll_CallsVehicleRepositoryGetAll()
		{
			// Arrange
			var expectedVehicles = new List<Vehicle>
			{
				new Vehicle
				{
					Id = 1,
					Plate = "ABC1234",
					Renavam = "12345678901",
					ChassiNumber = "12345678901234567",
					MotorNumber = "987654321",
					Brand = "Brand",
					Model = "Model",
					FuelId = 1,
					ColorId = 1,
					CreatedYear = 2020,
					Status = true,
					VehicleImage = new byte[0]
				},
				new Vehicle
				{
					Id = 2,
					Plate = "ABC4321",
					Renavam = "10987654321",
					ChassiNumber = "12345678901234567",
					MotorNumber = "123456789",
					Brand = "Brand New",
					Model = "Model New",
					FuelId = 5,
					ColorId = 9,
					CreatedYear = 2000,
					Status = false,
					VehicleImage = new byte[0]
				},

			};

			var vehicleRepositoryMock = new Mock<IVehicleRepository>();
			vehicleRepositoryMock.Setup(repo => repo.GetAll()).Returns(expectedVehicles);

			var contextMock = new Mock<ApplicationDbContext>();
			var vehicleService = new VehicleService(vehicleRepositoryMock.Object);

			// Act
			var actualVehicles = vehicleService.GetAll();

			// Assert
			Assert.Equal(expectedVehicles, actualVehicles);
		}

		[Fact]
		public void GetById_CallsVehicleRepositoryGetById()
		{
			// Arrange
			int id = 1;
			var expectedVehicle = new Vehicle
			{
				Id = 1,
				Plate = "ABC1234",
				Renavam = "12345678901",
				ChassiNumber = "12345678901234567",
				MotorNumber = "987654321",
				Brand = "Brand",
				Model = "Model",
				FuelId = 1,
				ColorId = 1,
				CreatedYear = 2020,
				Status = true,
				VehicleImage = new byte[0]
			};

			var vehicleRepositoryMock = new Mock<IVehicleRepository>();
			vehicleRepositoryMock.Setup(repo => repo.GetById(id)).Returns(expectedVehicle);

			var contextMock = new Mock<ApplicationDbContext>();
			var VehicleService = new VehicleService(vehicleRepositoryMock.Object);

			// Act
			var actualVehicle = VehicleService.GetById(id);

			// Assert
			Assert.Equal(expectedVehicle, actualVehicle);
		}
	}
}
