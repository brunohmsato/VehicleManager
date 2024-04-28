using VehicleManager.Domain.Models;

namespace VehicleManager.Domain.Interfaces
{
    public interface IColorRepository
    {
        void Add(Color color);

        List<Color> GetByDescriptionAndStatus(string description, bool status);

        List<Color> GetAll();

        Color GetById(int id);

        void Update(Color color);

        void Delete(int id);
    }
}