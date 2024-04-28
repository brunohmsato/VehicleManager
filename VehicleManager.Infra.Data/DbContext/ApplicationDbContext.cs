using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace VehicleManager.Infra.Data.DbContext
{
    public class ApplicationDbContext(IConfiguration configuration)
    {
        private readonly IConfiguration _configuration = configuration;
        private readonly string _connectionString = "Server=localhost;Database=vehicle_manager_db;User ID=sa;Password=1q2w3e4r@#$;";

        public IDbConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}