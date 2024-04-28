using VehicleManager.Domain.Models;

namespace VehicleManager.Domain.Interfaces
{
    public interface IFuelRepository
    {
        void Add(Fuel fuel);

        List<Fuel> GetAll();

        Fuel GetById(int id);

        void Update(Fuel fuel);

        void Delete(int id);
    }
}