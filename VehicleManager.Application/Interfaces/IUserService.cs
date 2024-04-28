using VehicleManager.Domain.Models;

namespace VehicleManager.Application.Interfaces
{
    public interface IUserService
    {
        User GetUser(string name, string password);
    }
}