using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ClientCore.Entities;
using ClientCore.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace ClientInterfaces.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly IConfiguration _configuration;

        public ClientRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> Add(Client entity)
        {
            var sql = "INSERT INTO Clients (Name, IdentificationCard) " +
                "Values (@Name, @IdentificationCard);";

            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("ClientConnection")))
                {
                    connection.Open();
                    var affectedRows = await connection.ExecuteAsync(sql, entity);
                    return affectedRows;
                }
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            try
            {
                var sql = "SELECT * FROM Clients;";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("ClientConnection")))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<Client>(sql);
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> Update(Client entity)
        {
            var sql = "UPDATE Clients SET Name = @Name, IdentificationCard = @IdentificationCard " +
                      "WHERE ID = @ID;";

            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("ClientConnection")))
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
