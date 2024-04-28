using VehicleManager.Application.Interfaces;
using VehicleManager.Domain.Interfaces;
using VehicleManager.Domain.Models;

namespace VehicleManager.Application.Services
{
    public class VehicleService(IVehicleRepository vehicleRepository) : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository = vehicleRepository;

        public void Add(Vehicle vehicle)
        {
            try
            {
                _vehicleRepository.Add(vehicle);
            }
            catch (Exception ex)
            {
            }
        }

        public List<Vehicle> GetAll()
        {
            try
            {
                return _vehicleRepository.GetAll();
            }
            catch (Exception ex)
            {
                return new List<Vehicle>();
            }
        }

        public Vehicle GetById(int id)
        {
            try
            {
                return _vehicleRepository.GetById(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void Update(Vehicle vehicle)
        {
            try
            {
                _vehicleRepository.Update(vehicle);
            }
            catch (Exception ex)
            {
            }
        }

        public void Delete(int id)
        {
            try
            {
                _vehicleRepository.Delete(id);
            }
            catch (Exception ex)
            {
            }
        }
    }
}