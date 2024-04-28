using VehicleManager.Application.Interfaces;
using VehicleManager.Domain.Interfaces;
using VehicleManager.Domain.Models;

namespace VehicleManager.Application.Services
{
    public class ColorService(IColorRepository colorRepository) : IColorService
    {
        private readonly IColorRepository _colorRepository = colorRepository;

        public void Add(Color color)
        {
            try
            {
                _colorRepository.Add(color);
            }
            catch (Exception ex)
            {
            }
        }

        public List<Color> GetColorsByDescriptionAndStatus(string description, bool status)
        {
            try
            {
                return _colorRepository.GetByDescriptionAndStatus(description, status);
            }
            catch (Exception ex)
            {
                return new List<Color>();
            }
        }

        public List<Color> GetAll()
        {
            try
            {
                return _colorRepository.GetAll();
            }
            catch (Exception ex)
            {
                return new List<Color>();
            }
        }

        public Color GetById(int id)
        {
            try
            {
                return _colorRepository.GetById(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void Update(Color color)
        {
            try
            {
                _colorRepository.Update(color);
            }
            catch (Exception ex)
            {
            }
        }

        public void Delete(int id)
        {
            try
            {
                _colorRepository.Delete(id);
            }
            catch (Exception ex)
            {
            }
        }
    }
}