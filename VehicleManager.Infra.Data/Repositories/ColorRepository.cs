using VehicleManager.Domain.Interfaces;
using VehicleManager.Domain.Models;
using VehicleManager.Infra.Data.DbContext;

namespace VehicleManager.Infra.Data.Repositories
{
    public class ColorRepository(ApplicationDbContext contextDb) : IColorRepository
    {
        private readonly ApplicationDbContext _context = contextDb;

        public void Add(Color color)
        {
            try
            {
                using var connection = _context.GetConnection();
                using var command = connection.CreateCommand();

                connection.Open();
                command.CommandText = "INSERT INTO [color] (description, status) VALUES (@description, @status)";

                var descriptionParameter = command.CreateParameter();
                descriptionParameter.ParameterName = "@description";
                descriptionParameter.Value = color.Description;
                command.Parameters.Add(descriptionParameter);

                var statusParameter = command.CreateParameter();
                statusParameter.ParameterName = "@status";
                statusParameter.Value = color.Status;
                command.Parameters.Add(statusParameter);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
        }

        public List<Color> GetByDescriptionAndStatus(string description, bool status)
        {
            try
            {
                var colors = new List<Color>();

                using var connection = _context.GetConnection();
                using var command = connection.CreateCommand();

                connection.Open();

                command.CommandText = "SELECT * FROM [color] WHERE description = @description AND status = @status";

                var descriptionParameter = command.CreateParameter();
                descriptionParameter.ParameterName = "@description";
                descriptionParameter.Value = description;
                command.Parameters.Add(descriptionParameter);

                var statusParameter = command.CreateParameter();
                statusParameter.ParameterName = "@status";
                statusParameter.Value = status;
                command.Parameters.Add(statusParameter);

                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    colors.Add(new Color
                    {
                        Id = reader.GetInt32(0),
                        Description = reader.GetString(1),
                        Status = reader.GetBoolean(2)
                    });
                }
                return colors;
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
                var colors = new List<Color>();

                using var connection = _context.GetConnection();
                using var command = connection.CreateCommand();

                connection.Open();

                command.CommandText = "SELECT * FROM [color]";

                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    colors.Add(new Color
                    {
                        Id = reader.GetInt32(0),
                        Description = reader.GetString(1),
                        Status = reader.GetBoolean(2)
                    });
                }
                return colors;
            }
            catch (Exception ex)
            {
                return new List<Color>();
            }
        }

        public Color GetById(int id)
        {
            using var connection = _context.GetConnection();
            using var command = connection.CreateCommand();

            connection.Open();

            command.CommandText = "SELECT * FROM [color] WHERE id = @id";

            var idParameter = command.CreateParameter();
            idParameter.ParameterName = "@id";
            idParameter.Value = id;
            command.Parameters.Add(idParameter);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Color
                {
                    Id = reader.GetInt32(0),
                    Description = reader.GetString(1),
                    Status = reader.GetBoolean(2)
                };
            }

            return null;
        }

        public void Update(Color color)
        {
            try
            {
                using var connection = _context.GetConnection();
                using var command = connection.CreateCommand();

                connection.Open();

                command.CommandText = "UPDATE [color] SET description = @description, status = @status WHERE id = @id";

                var descriptionParameter = command.CreateParameter();
                descriptionParameter.ParameterName = "@description";
                descriptionParameter.Value = color.Description;
                command.Parameters.Add(descriptionParameter);

                var statusParameter = command.CreateParameter();
                statusParameter.ParameterName = "@status";
                statusParameter.Value = color.Status;
                command.Parameters.Add(statusParameter);

                var idParameter = command.CreateParameter();
                idParameter.ParameterName = "@id";
                idParameter.Value = color.Id;
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

                command.CommandText = "DELETE FROM [color] WHERE id = @id";

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