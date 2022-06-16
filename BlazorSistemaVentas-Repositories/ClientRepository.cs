using BlazorSistemaVentas.Shared;
using Dapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSistemaVentas_Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly IDbConnection _dbConnection;
        private readonly ILogger<ClientRepository> _logger;

        public ClientRepository(IDbConnection dbConnection, ILogger<ClientRepository> logger)
        {
            _dbConnection = dbConnection;
            _logger = logger;
        }
        public async Task<IEnumerable<Client>> GetAllClients()
        {
            var sql = @"SELECT *
                        FROM Clients";

            _logger.LogInformation($"INICIO - GetAll SQL: {sql}");

            var request = await _dbConnection.QueryAsync<Client>(sql, new { });

            _logger.LogInformation($"FIN - GetAll respuesta: {request}");

            return request;

        }
    }
}
