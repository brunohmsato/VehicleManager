using Moq;
using VehicleManager.Application.Services;
using VehicleManager.Domain.Interfaces;
using VehicleManager.Domain.Models;
using VehicleManager.Infra.Data.DbContext;

namespace VehicleManager.Test.Services.ColorTest
{
	public class ColorAddTest
	{
		[Fact]
		public void Add_ValidColor_CallsColorRepositoryAdd()
		{
			// Arrange
			var color = new Color { Id = 1, Description = "Blue", Status = true };
			var colorRepositoryMock = new Mock<IColorRepository>();
			var contextMock = new Mock<ApplicationDbContext>();
			var colorService = new ColorService(colorRepositoryMock.Object);

			// Act
			colorService.Add(color);

			// Assert
			colorRepositoryMock.Verify(repo => repo.Add(color), Times.Once);
		}
	}
}
