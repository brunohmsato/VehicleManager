using System.Data;
using VehicleManager.Domain.Interfaces;
using VehicleManager.Domain.Models;
using VehicleManager.Infra.Data.DbContext;

namespace VehicleManager.Infra.Data.Repositories
{
    public class VehicleRepository(ApplicationDbContext contextDb) : IVehicleRepository
    {
        private readonly ApplicationDbContext _context = contextDb;

        public void Add(Vehicle vehicle)
        {
            try
            {
                using var connection = _context.GetConnection();
                using var command = connection.CreateCommand();

                connection.Open();
                command.CommandText = "INSERT INTO [vehicle] (plate, renavam, chassi_number, motor_number, brand, model, fuel_id, color_id, manufacturing_year, status, vehicle_images)" +
                    "VALUES (@plate, @renavam, @chassi, @motor, @brand, @model, @fuel_id, @color_id, @manufacturing_year, @status, @image)";

                var plateParameter = command.CreateParameter();
                plateParameter.ParameterName = "@plate";
                plateParameter.Value = vehicle.Plate;
                command.Parameters.Add(plateParameter);

                var renavamParameter = command.CreateParameter();
                renavamParameter.ParameterName = "@renavam";
                renavamParameter.Value = vehicle.Renavam;
                command.Parameters.Add(renavamParameter);

                var chassiParameter = command.CreateParameter();
                chassiParameter.ParameterName = "@chassi";
                chassiParameter.Value = vehicle.ChassiNumber;
                command.Parameters.Add(chassiParameter);

                var motorParameter = command.CreateParameter();
                motorParameter.ParameterName = "@motor";
                motorParameter.Value = vehicle.MotorNumber;
                command.Parameters.Add(motorParameter);

                var brandParameter = command.CreateParameter();
                brandParameter.ParameterName = "@brand";
                brandParameter.Value = vehicle.Brand;
                command.Parameters.Add(brandParameter);

                var modelParameter = command.CreateParameter();
                modelParameter.ParameterName = "@model";
                modelParameter.Value = vehicle.Model;
                command.Parameters.Add(modelParameter);

                var fuelIdParameter = command.CreateParameter();
                fuelIdParameter.ParameterName = "@fuel_id";
                fuelIdParameter.Value = vehicle.FuelId;
                command.Parameters.Add(fuelIdParameter);

                var colorIdParameter = command.CreateParameter();
                colorIdParameter.ParameterName = "@color_id";
                colorIdParameter.Value = vehicle.ColorId;
                command.Parameters.Add(colorIdParameter);

                var manufacturingYearParameter = command.CreateParameter();
                manufacturingYearParameter.ParameterName = "@manufacturing_year";
                manufacturingYearParameter.Value = vehicle.CreatedYear;
                command.Parameters.Add(manufacturingYearParameter);

                var statusParameter = command.CreateParameter();
                statusParameter.ParameterName = "@status";
                statusParameter.Value = vehicle.Status;
                command.Parameters.Add(statusParameter);

                var imageParameter = command.CreateParameter();
                imageParameter.ParameterName = "@image";
                imageParameter.Value = vehicle.VehicleImage ?? (object)DBNull.Value;
                imageParameter.DbType = DbType.Binary;
                command.Parameters.Add(imageParameter);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
        }

        public List<Vehicle> GetAll()
        {
            try
            {
                var vehicles = new List<Vehicle>();

                using var connection = _context.GetConnection();
                using var command = connection.CreateCommand();

                connection.Open();

                command.CommandText = @"
                    SELECT v.id, v.plate, v.renavam, v.chassi_number, v.motor_number, v.brand, v.model, v.fuel_id, v.color_id,
                    f.description AS fuel_description, c.description AS color_description,
                    v.manufacturing_year, v.status
                    FROM vehicle v
                    JOIN fuel f ON v.fuel_id = f.id
                    JOIN color c ON v.color_id = c.id";

                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    vehicles.Add(new Vehicle
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Plate = Convert.ToString(reader["plate"]),
                        Renavam = Convert.ToString(reader["renavam"]),
                        ChassiNumber = Convert.ToString(reader["chassi_number"]),
                        MotorNumber = Convert.ToString(reader["motor_number"]),
                        Brand = Convert.ToString(reader["brand"]),
                        Model = Convert.ToString(reader["model"]),
                        FuelId = Convert.ToInt32(reader["fuel_id"]),
                        ColorId = Convert.ToInt32(reader["color_id"]),
                        SelectedFuelDescription = Convert.ToString(reader["fuel_description"]),
                        SelectedColorDescription = Convert.ToString(reader["color_description"]),
                        CreatedYear = Convert.ToInt32(reader["manufacturing_year"]),
                        Status = Convert.ToBoolean(reader["status"])
                    });
                }
                return vehicles;
            }
            catch (Exception ex)
            {
                return new List<Vehicle>();
            }
        }

        public Vehicle GetById(int id)
        {
            using var connection = _context.GetConnection();
            using var command = connection.CreateCommand();

            connection.Open();

            command.CommandText = @"
                SELECT v.id, v.plate, v.renavam, v.chassi_number, v.motor_number, v.brand, v.model, v.fuel_id, v.color_id,
                f.description AS fuel_description, c.description AS color_description,
                v.manufacturing_year, v.status, v.vehicle_images
                FROM vehicle v
                JOIN fuel f ON v.fuel_id = f.id
                JOIN color c ON v.color_id = c.id
                WHERE v.id = @id;
                ";

            var idParameter = command.CreateParameter();
            idParameter.ParameterName = "@id";
            idParameter.Value = id;
            command.Parameters.Add(idParameter);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                var vehicle = new Vehicle
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Plate = Convert.ToString(reader["plate"]),
                    Renavam = Convert.ToString(reader["renavam"]),
                    ChassiNumber = Convert.ToString(reader["chassi_number"]),
                    MotorNumber = Convert.ToString(reader["motor_number"]),
                    Brand = Convert.ToString(reader["brand"]),
                    Model = Convert.ToString(reader["model"]),
                    FuelId = Convert.ToInt32(reader["fuel_id"]),
                    ColorId = Convert.ToInt32(reader["color_id"]),
                    SelectedFuelDescription = Convert.ToString(reader["fuel_description"]),
                    SelectedColorDescription = Convert.ToString(reader["color_description"]),
                    CreatedYear = Convert.ToInt32(reader["manufacturing_year"]),
                    Status = Convert.ToBoolean(reader["status"])
                };

                if (!reader.IsDBNull(reader.GetOrdinal("vehicle_images")))
                {
                    vehicle.VehicleImage = (byte[])reader["vehicle_images"];
                }

                return vehicle;
            }

            return null;
        }

        public void Update(Vehicle vehicle)
        {
            try
            {
                using var connection = _context.GetConnection();
                using var command = connection.CreateCommand();

                connection.Open();

                command.CommandText = "UPDATE [vehicle] SET plate = @plate, renavam = @renavam, chassi_number = @chassi, " +
                    "motor_number = @motor, brand = @brand, model = @model, fuel_id = @fuel_id, color_id = @color_id, " +
                    "manufacturing_year = @manufacturing_year, status = @status, vehicle_images = @image WHERE id = @id";

                var plateParameter = command.CreateParameter();
                plateParameter.ParameterName = "@plate";
                plateParameter.Value = vehicle.Plate;
                command.Parameters.Add(plateParameter);

                var renavamParameter = command.CreateParameter();
                renavamParameter.ParameterName = "@renavam";
                renavamParameter.Value = vehicle.Renavam;
                command.Parameters.Add(renavamParameter);

                var chassiParameter = command.CreateParameter();
                chassiParameter.ParameterName = "@chassi";
                chassiParameter.Value = vehicle.ChassiNumber;
                command.Parameters.Add(chassiParameter);

                var motorParameter = command.CreateParameter();
                motorParameter.ParameterName = "@motor";
                motorParameter.Value = vehicle.MotorNumber;
                command.Parameters.Add(motorParameter);

                var brandParameter = command.CreateParameter();
                brandParameter.ParameterName = "@brand";
                brandParameter.Value = vehicle.Brand;
                command.Parameters.Add(brandParameter);

                var modelParameter = command.CreateParameter();
                modelParameter.ParameterName = "@model";
                modelParameter.Value = vehicle.Model;
                command.Parameters.Add(modelParameter);

                var fuelIdParameter = command.CreateParameter();
                fuelIdParameter.ParameterName = "@fuel_id";
                fuelIdParameter.Value = vehicle.FuelId;
                command.Parameters.Add(fuelIdParameter);

                var colorIdParameter = command.CreateParameter();
                colorIdParameter.ParameterName = "@color_id";
                colorIdParameter.Value = vehicle.ColorId;
                command.Parameters.Add(colorIdParameter);

                var manufacturingYearParameter = command.CreateParameter();
                manufacturingYearParameter.ParameterName = "@manufacturing_year";
                manufacturingYearParameter.Value = vehicle.CreatedYear;
                command.Parameters.Add(manufacturingYearParameter);

                var statusParameter = command.CreateParameter();
                statusParameter.ParameterName = "@status";
                statusParameter.Value = vehicle.Status;
                command.Parameters.Add(statusParameter);

                var imageParameter = command.CreateParameter();
                imageParameter.ParameterName = "@image";
                imageParameter.Value = vehicle.VehicleImage ?? (object)DBNull.Value;
                imageParameter.DbType = DbType.Binary;
                command.Parameters.Add(imageParameter);

                var idParameter = command.CreateParameter();
                idParameter.ParameterName = "@id";
                idParameter.Value = vehicle.Id;
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

                command.CommandText = "DELETE FROM [vehicle] WHERE id = @id";

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