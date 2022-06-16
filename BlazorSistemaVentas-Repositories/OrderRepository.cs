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
    public class OrderRepository : IOrderRepository
    {
        private readonly IDbConnection _dbConnection;
        private readonly ILogger<OrderRepository> _logger;

        public OrderRepository(IDbConnection dbConnection, ILogger<OrderRepository> logger)
        {
            _dbConnection = dbConnection;
            _logger = logger;
        }

        public async Task<bool> InserOrder(Order order)
        {
            var sql = @"INSERT INTO Orders (OrderNumber, ClientId, OrderDate, DeliveryDate, TotalOrders)
                        values(@OrderNumber, @ClientId, @OrderDate, @DeliveryDate, @TotalOrders)";

            _logger.LogInformation($"INICIO - InserOrder SQL: {sql}");

            var request = await _dbConnection.ExecuteAsync(sql, new
            {
                OrderNumber = order.OrderNumber,
                ClientId = order.ClientId,
                OrderDate = order.OrderDate,
                DeliveryDate = order.DeliveryDate,
                TotalOrders = order.Total
            });

            _logger.LogInformation($"FIN - InserOrder respuesta: {request}");

            return request > 0 ;

        }
    }
}
