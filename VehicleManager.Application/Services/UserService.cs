using VehicleManager.Application.Interfaces;
using VehicleManager.Domain.Interfaces;
using VehicleManager.Domain.Models;

namespace VehicleManager.Application.Services
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;

        public User GetUser(string name, string password)
        {
            try
            {
                return _userRepository.GetUser(name, password);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}