using VehicleManager.Domain.Models;

namespace VehicleManager.Application.Interfaces
{
    public interface IColorService
    {
        void Add(Color color);

        List<Color> GetColorsByDescriptionAndStatus(string description, bool status);

        public List<Color> GetAll();

        Color GetById(int id);

        void Update(Color color);

        void Delete(int id);
    }
}