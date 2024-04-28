using Moq;
using VehicleManager.Application.Services;
using VehicleManager.Domain.Interfaces;
using VehicleManager.Infra.Data.DbContext;

namespace VehicleManager.Test.Services.ColorTest
{
    public class ColorDeleteTest
    {
        [Fact]
        public void Delete_CallsColorRepositoryDelete()
        {
            // Arrange
            int idToDelete = 1;

            var colorRepositoryMock = new Mock<IColorRepository>();
            var contextMock = new Mock<ApplicationDbContext>();
            var colorService = new ColorService(colorRepositoryMock.Object);

            // Act
            colorService.Delete(idToDelete);

            // Assert
            colorRepositoryMock.Verify(repo => repo.Delete(idToDelete), Times.Once);
        }
    }
}