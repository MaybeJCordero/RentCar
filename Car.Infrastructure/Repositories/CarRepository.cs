using CarCore.Entities;
using CarCore.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace CarInfrastructure.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly IConfiguration _configuration;

        public CarRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<Car>> GetAll()
        {
            try
            {
                var sql = "SELECT * FROM Cars";

                using (var connection = new SqlConnection(_configuration.GetConnectionString("CarConnection")))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<Car>(sql);
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> Add(Car entity)
        {
            var sql = "INSERT INTO Cars (Description, Brand, Model, Rent, ClientID, ClientName) " +
                "Values (@Description, @Brand, @Model, @Rent, @ClientID, @ClientName);";

            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("CarConnection")))
                {
                    connection.Open();
                    var affectedRows = await connection.ExecuteAsync(sql, entity);
                    return affectedRows;
                }
            }
            catch(Exception e)
            {
                throw;
            }
        }

        public async Task<int> Update(Car entity)
        {
            var sql = "UPDATE Cars SET Description = @Description, Brand = @Brand, Model = @Model, " +
                "Rent = @Rent, ClientID = @ClientID, ClientName = @ClientName " +
                "WHERE ID = @ID;";

            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("CarConnection")))
                {
                    connection.Open();
                    var affectedRows = await connection.ExecuteAsync(sql, entity);
                    return affectedRows;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
