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

            IEnumerable<Product> list = await _dbConnection.QueryAsync<Product>(sql, new { Id = productCategoryId });

            _logger.LogInformation($"FIN - GetAll respuesta: {list}");

            return list;
        }
    }
}
