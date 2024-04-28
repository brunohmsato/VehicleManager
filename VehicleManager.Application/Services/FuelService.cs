using VehicleManager.Application.Interfaces;
using VehicleManager.Domain.Interfaces;
using VehicleManager.Domain.Models;

namespace VehicleManager.Application.Services
{
    public class FuelService(IFuelRepository fuelRepository) : IFuelService
    {
        private readonly IFuelRepository _fuelRepository = fuelRepository;

        public void Add(Fuel fuel)
        {
            try
            {
                _fuelRepository.Add(fuel);
            }
            catch (Exception ex)
            {
            }
        }

        public List<Fuel> GetAll()
        {
            try
            {
                return _fuelRepository.GetAll();
            }
            catch (Exception ex)
            {
                return new List<Fuel>();
            }
        }

        public Fuel GetById(int id)
        {
            try
            {
                return _fuelRepository.GetById(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void Update(Fuel fuel)
        {
            try
            {
                _fuelRepository.Update(fuel);
            }
            catch (Exception ex)
            {
            }
        }

        public void Delete(int id)
        {
            try
            {
                _fuelRepository.Delete(id);
            }
            catch (Exception ex)
            {
            }
        }
    }
}