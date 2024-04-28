using Moq;
using VehicleManager.Application.Services;
using VehicleManager.Domain.Interfaces;
using VehicleManager.Domain.Models;
using VehicleManager.Infra.Data.DbContext;

namespace VehicleManager.Test.Services.ColorTest
{
    public class ColorUpdateTest
    {
        [Fact]
        public void Update_CallsColorRepositoryUpdate()
        {
            // Arrange
            var colorToUpdate = new Color { Id = 1, Description = "Blue", Status = true };

            var colorRepositoryMock = new Mock<IColorRepository>();
            var contextMock = new Mock<ApplicationDbContext>();
            var colorService = new ColorService(colorRepositoryMock.Object);

            // Act

            colorService.Update(colorToUpdate);

            // Assert
            colorRepositoryMock.Verify(repo => repo.Update(colorToUpdate), Times.Once);
        }
    }
}