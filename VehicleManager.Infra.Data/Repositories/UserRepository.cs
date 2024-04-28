using VehicleManager.Domain.Interfaces;
using VehicleManager.Domain.Models;
using VehicleManager.Infra.Data.DbContext;

namespace VehicleManager.Infra.Data.Repositories
{
    public class UserRepository(ApplicationDbContext contextDb) : IUserRepository
    {
        private readonly ApplicationDbContext _context = contextDb;

        public User GetUser(string login, string password)
        {
            using var connection = _context.GetConnection();
            using var command = connection.CreateCommand();

            connection.Open();

            command.CommandText = "SELECT * FROM [user] WHERE Login = @Login AND Password = @Password";

            var loginParameter = command.CreateParameter();
            loginParameter.ParameterName = "@Login";
            loginParameter.Value = login;
            command.Parameters.Add(loginParameter);

            var passwordParameter = command.CreateParameter();
            passwordParameter.ParameterName = "@Password";
            passwordParameter.Value = password;
            command.Parameters.Add(passwordParameter);

            using var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new User
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Name = reader["nome"].ToString(),
                    Login = reader["login"].ToString(),
                    Password = reader["password"].ToString(),
                    isAdmin = Convert.ToBoolean(reader["isAdmin"])
                };
            }

            return null;
        }
    }
}