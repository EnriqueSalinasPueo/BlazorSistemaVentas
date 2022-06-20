using BlazorSistemaVentas.Shared;
using Dapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
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

        public async Task<IEnumerable<Product>> GetByOrder(int orderId)
        {
            var sql = @"SELECT Id
                              , Name
                              , p.Price
                              ,p.CategoryId As ProductCategoryId
	                          ,o.Quantity
                          FROM OrderProducts o
                          inner join Products p ON p.Id = o.ProductId
                          WHERE o.OrderId = @Id";

            _logger.LogInformation($"INICIO - GetByOrder");

            var result = await _dbConnection.QueryAsync<Product>(sql, new { Id = orderId });

            _logger.LogInformation($"FIN - GetByOrder result; {result}");

            return result;
        }

        public async Task<bool> DeleteOrderProductByOrder(int orderId)
        {
            var sql = @"DELETE FROM  OrderProducts
                        WHERE OrderId = @Id";

            _logger.LogInformation($"INICIO - DeleteOrderProductByOrder");

            var result = await _dbConnection.ExecuteAsync(sql, new { Id = orderId });

            _logger.LogInformation($"FIN - DeleteOrderProductByOrder result; {result}");

            return result > 0;
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
