using BlazorSistemaVentas.Shared;
using Dapper;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Threading.Tasks;

namespace BlazorSistemaVentas_Repositories
{
    public class OrderProductRepository : IOrderProductRepository
    {
        private readonly IDbConnection _dbConnection;

        private readonly ILogger<OrderProductRepository> _logger;

        public OrderProductRepository(IDbConnection dbConnection, ILogger<OrderProductRepository> logger)
        {
            _dbConnection = dbConnection;
            _logger = logger;
        }

        public async Task<bool> InserOrderProduct(int orderId, Product product)
        {
            var sql = "INSERT INTO OrderProducts(OrderId, ProductId, Quantity)" +
                      "VALUES(@OrderId, @ProductId, @Quantity)";

            _logger.LogInformation($"INICIO - InserOrderProduct");

            var result = await _dbConnection.ExecuteAsync(sql, new
            {
                OrderId = orderId,
                ProductId = product.Id,
                Quantity = product.Quantity
            });

            _logger.LogInformation($"FIN - InserOrderProduct result; {result}");

            return result > 0;
        }
    }
}
