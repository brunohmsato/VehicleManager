using VehicleManager.Domain.Models;

namespace VehicleManager.Application.Interfaces
{
    public interface IFuelService
    {
        void Add(Fuel fuel);

        List<Fuel> GetAll();

        Fuel GetById(int id);

        void Update(Fuel fuel);

        void Delete(int id);
    }
}