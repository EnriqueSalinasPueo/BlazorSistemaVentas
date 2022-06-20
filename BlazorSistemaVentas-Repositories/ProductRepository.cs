using BlazorSistemaVentas.Shared;
using Dapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace BlazorSistemaVentas_Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _dbConnection;
        private readonly ILogger<ProductRepository> _logger;

        public ProductRepository(IDbConnection dbConnection, ILogger<ProductRepository> logger)
        {
            _dbConnection = dbConnection;
            _logger = logger;
        }
        public async Task<IEnumerable<Product>> GetByCategory(int productCategoryId)
        {
            var sql = @"SELECT *
                      FROM Products
                      WHERE CategoryId = @Id";

            _logger.LogInformation($"INICIO - GetAll SQL: {sql}");

            var request = await _dbConnection.QueryAsync<Product>(sql, new { Id = productCategoryId });

            _logger.LogInformation($"FIN - GetAll respuesta: {request}");

            return request;
        }

        public async Task<Product> GetDetails(int productId)
        {
            var sql = @"SELECT *
                      FROM Products
                      WHERE Id = @Id";

            _logger.LogInformation($"INICIO - GetDetails SQL: {sql}");

            var request = await _dbConnection.QueryFirstOrDefaultAsync<Product>(sql, new { Id = productId });

            _logger.LogInformation($"FIN - GetDetails respuesta: {request}");

            return request;
        }
    }
}
