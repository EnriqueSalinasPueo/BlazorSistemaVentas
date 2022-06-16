using BlazorSistemaVentas.Shared;
using Dapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace BlazorSistemaVentas_Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly IDbConnection _dbConnection;
        private readonly ILogger<ProductCategoryRepository> _logger;

        public ProductCategoryRepository(IDbConnection dbConnection, ILogger<ProductCategoryRepository> logger)
        {
            _dbConnection = dbConnection;
            _logger = logger;
        }

        public async Task<IEnumerable<ProductCategory>> GetAll()
        {
            var sql = @"SELECT Id as Id, Name as Name
                        FROM ProductCategories";

            _logger.LogInformation($"INICIO - GetAll SQL: {sql}");

            IEnumerable<ProductCategory> list = await _dbConnection.QueryAsync<ProductCategory>(sql, new { });

            _logger.LogInformation($"FIN - GetAll respuesta: {list}");

            return list;
        }
    }
}
