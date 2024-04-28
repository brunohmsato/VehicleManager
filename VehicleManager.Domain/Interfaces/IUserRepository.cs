using VehicleManager.Domain.Models;

namespace VehicleManager.Domain.Interfaces
{
    public interface IUserRepository
    {
        User GetUser(string login, string password);
    }
}