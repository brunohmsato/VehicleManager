using VehicleManager.Domain.Models;

namespace VehicleManager.Domain.Interfaces
{
    public interface IVehicleRepository
    {
        void Add(Vehicle vehicle);

        List<Vehicle> GetAll();

        Vehicle GetById(int id);

        void Update(Vehicle vehicle);

        void Delete(int id);
    }
}