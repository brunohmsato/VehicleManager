using VehicleManager.Domain.Models;

namespace VehicleManager.Application.Interfaces
{
    public interface IVehicleService
    {
        void Add(Vehicle vehicle);

        List<Vehicle> GetAll();

        Vehicle GetById(int id);

        void Update(Vehicle vehicle);

        void Delete(int id);
    }
}
