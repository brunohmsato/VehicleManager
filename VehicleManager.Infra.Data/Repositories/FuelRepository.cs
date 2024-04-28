using VehicleManager.Domain.Interfaces;
using VehicleManager.Domain.Models;
using VehicleManager.Infra.Data.DbContext;

namespace VehicleManager.Infra.Data.Repositories
{
    public class FuelRepository(ApplicationDbContext contextDb) : IFuelRepository
    {
        private readonly ApplicationDbContext _context = contextDb;

        public void Add(Fuel fuel)
        {
            try
            {
                using var connection = _context.GetConnection();
                using var command = connection.CreateCommand();

                connection.Open();
                command.CommandText = "INSERT INTO [fuel] (description, status) VALUES (@description, @status)";

                var descriptionParameter = command.CreateParameter();
                descriptionParameter.ParameterName = "@description";
                descriptionParameter.Value = fuel.Description;
                command.Parameters.Add(descriptionParameter);

                var statusParameter = command.CreateParameter();
                statusParameter.ParameterName = "@status";
                statusParameter.Value = fuel.Status;
                command.Parameters.Add(statusParameter);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
        }

        public List<Fuel> GetAll()
        {
            try
            {
                var fuels = new List<Fuel>();

                using var connection = _context.GetConnection();
                using var command = connection.CreateCommand();

                connection.Open();

                command.CommandText = "SELECT * FROM [fuel]";

                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    fuels.Add(new Fuel
                    {
                        Id = reader.GetInt32(0),
                        Description = reader.GetString(1),
                        Status = reader.GetBoolean(2)
                    });
                }
                return fuels;
            }
            catch (Exception ex)
            {
                return new List<Fuel>();
            }
        }

        public Fuel GetById(int id)
        {
            using var connection = _context.GetConnection();
            using var command = connection.CreateCommand();

            connection.Open();

            command.CommandText = "SELECT * FROM [fuel] WHERE id = @id";

            var idParameter = command.CreateParameter();
            idParameter.ParameterName = "@id";
            idParameter.Value = id;
            command.Parameters.Add(idParameter);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Fuel
                {
                    Id = reader.GetInt32(0),
                    Description = reader.GetString(1),
                    Status = reader.GetBoolean(2)
                };
            }

            return null;
        }

        public void Update(Fuel fuel)
        {
            try
            {
                using var connection = _context.GetConnection();
                using var command = connection.CreateCommand();

                connection.Open();

                command.CommandText = "UPDATE [fuel] SET description = @description, status = @status WHERE id = @id";

                var descriptionParameter = command.CreateParameter();
                descriptionParameter.ParameterName = "@description";
                descriptionParameter.Value = fuel.Description;
                command.Parameters.Add(descriptionParameter);

                var statusParameter = command.CreateParameter();
                statusParameter.ParameterName = "@status";
                statusParameter.Value = fuel.Status;
                command.Parameters.Add(statusParameter);

                var idParameter = command.CreateParameter();
                idParameter.ParameterName = "@id";
                idParameter.Value = fuel.Id;
                command.Parameters.Add(idParameter);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
        }

        public void Delete(int id)
        {
            try
            {
                using var connection = _context.GetConnection();
                using var command = connection.CreateCommand();

                connection.Open();

                command.CommandText = "DELETE FROM [fuel] WHERE id = @id";

                var idParameter = command.CreateParameter();
                idParameter.ParameterName = "@id";
                idParameter.Value = id;
                command.Parameters.Add(idParameter);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
        }
    }
}