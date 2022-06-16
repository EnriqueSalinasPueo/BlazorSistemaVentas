using BlazorSistemaVentas.Shared;
using Dapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace BlazorSistemaVentas_Repositories
{
    public class ProductCategoryRepositiry : IProductCategoryRepositiry
    {
        private readonly IDbConnection _dbConnection;
        private readonly ILogger<ProductCategoryRepositiry> _logger;

        public ProductCategoryRepositiry(IDbConnection dbConnection, ILogger<ProductCategoryRepositiry> logger)
        {
            _dbConnection = dbConnection;
            _logger = logger;
        }

        public async Task<IEnumerable<ProductCategory>> GetAll()
        {
            var sql = @"SELECT Id as Id, Name as Name
                        FROM ProductCategories";

            _logger.LogInformation("INICIO - Repositiry ProductCategoryRepositiry GetAll SQL: " + sql);

            IEnumerable<ProductCategory> list = await _dbConnection.QueryAsync<ProductCategory>(sql, new { });

            _logger.LogInformation("FIN - Repositiry ProductCategoryRepositiry GetAll respuesta: " + list);

            return list;
        }
    }
}
