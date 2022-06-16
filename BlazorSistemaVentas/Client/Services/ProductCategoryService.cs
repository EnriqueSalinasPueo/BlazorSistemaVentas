using BlazorSistemaVentas.Shared;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorSistemaVentas.Client.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly HttpClient _httpclient;
        private readonly ILogger<ProductCategoryService> _logger;
        public ProductCategoryService(HttpClient httpclient, ILogger<ProductCategoryService> logger)
        {
            _httpclient = httpclient;
            _logger = logger;
        }
        public async Task<IEnumerable<ProductCategory>> GetAll()
        {
            _logger.LogInformation($"INICIO - GetAll");

            IEnumerable<ProductCategory> list = await _httpclient.GetFromJsonAsync<IEnumerable<ProductCategory>>($"api/ProductCategory");

            _logger.LogInformation($"FIN - GetAll list: {list}");

            return list;
        }

    }
}
