﻿using Moq;
using VehicleManager.Application.Services;
using VehicleManager.Domain.Interfaces;
using VehicleManager.Domain.Models;
using VehicleManager.Infra.Data.DbContext;

namespace VehicleManager.Test.Services.VehicleTest
{
    public class VehicleUpdateTest
    {
        [Fact]
        public void Update_CallsVehicleRepositoryUpdate()
        {
            // Arrange
            var vehicleToUpdate = new Vehicle
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
            var contextMock = new Mock<ApplicationDbContext>();
            var vehicleService = new VehicleService(vehicleRepositoryMock.Object);

            // Act

            vehicleService.Update(vehicleToUpdate);

            // Assert
            vehicleRepositoryMock.Verify(repo => repo.Update(vehicleToUpdate), Times.Once);
        }
    }
}