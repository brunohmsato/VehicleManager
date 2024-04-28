using Moq;
using VehicleManager.Application.Services;
using VehicleManager.Domain.Interfaces;
using VehicleManager.Domain.Models;
using VehicleManager.Infra.Data.DbContext;

namespace VehicleManager.Test.Services.ColorTest
{
	public class ColorGetTest
	{
		[Fact]
		public void GetAll_CallsColorRepositoryGetAll()
		{
			// Arrange
			var expectedColors = new List<Color>
			{
				new Color { Id = 1, Description = "Blue", Status = true },
				new Color { Id = 2, Description = "Gray", Status = false },
			};

			var colorRepositoryMock = new Mock<IColorRepository>();
			colorRepositoryMock.Setup(repo => repo.GetAll()).Returns(expectedColors);

			var contextMock = new Mock<ApplicationDbContext>();
			var colorService = new ColorService(colorRepositoryMock.Object);

			// Act
			var actualColors = colorService.GetAll();

			// Assert
			Assert.Equal(expectedColors, actualColors);
		}

		[Fact]
		public void GetById_CallsColorRepositoryGetById()
		{
			// Arrange
			int id = 1;
			var expectedColor = new Color { Id = id, Description = "Blue", Status = true };

			var colorRepositoryMock = new Mock<IColorRepository>();
			colorRepositoryMock.Setup(repo => repo.GetById(id)).Returns(expectedColor);

			var contextMock = new Mock<ApplicationDbContext>();
			var colorService = new ColorService(colorRepositoryMock.Object);

			// Act
			var actualColor = colorService.GetById(id);

			// Assert
			Assert.Equal(expectedColor, actualColor);
		}
	}
}
