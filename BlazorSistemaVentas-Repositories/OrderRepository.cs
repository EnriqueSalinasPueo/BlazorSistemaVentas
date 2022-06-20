﻿using BlazorSistemaVentas.Shared;
using Dapper;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Threading.Tasks;

namespace BlazorSistemaVentas_Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IDbConnection _dbConnection;
        private readonly ILogger<OrderRepository> _logger;

        public OrderRepository(IDbConnection dbConnection, ILogger<OrderRepository> logger)
        {
            _dbConnection = dbConnection;
            _logger = logger;
        }

        public async Task<int> GetNextId()
        {
            var sql = @"SELECT IDENT_CURRENT('Orders') + 1";

            _logger.LogInformation($"INICIO - GetNextId SQL: {sql}");

            var request = await _dbConnection.ExecuteAsync(sql, new { });

            _logger.LogInformation($"FIN - GetNextId respuesta: {request}");

            return request;
        }

        public async Task<int> GetNextNumber()
        {
            var sql = @"SELECT MAX(OrderNumber) + 1
                        FROM Orders";

            _logger.LogInformation($"INICIO - GetNextNumber SQL: {sql}");

            var request = await _dbConnection.ExecuteAsync(sql, new { });

            _logger.LogInformation($"FIN - GetNextNumber respuesta: {request}");

            return request;
        }

        public async Task<bool> InserOrder(Order order)
        {
            var sql = @"INSERT INTO Orders (OrderNumber, ClientId, OrderDate, DeliveryDate, Total)
                        values(@OrderNumber, @ClientId, @OrderDate, @DeliveryDate, @Total)";

            _logger.LogInformation($"INICIO - InserOrder SQL: {sql}");

            var request = await _dbConnection.ExecuteAsync(sql, new
            {
                OrderNumber = order.OrderNumber,
                ClientId = order.ClientId,
                OrderDate = order.OrderDate,
                DeliveryDate = order.DeliveryDate,
                Total = order.Total
            });

            _logger.LogInformation($"FIN - InserOrder respuesta: {request}");

            return request > 0 ;

        }
    }
}
