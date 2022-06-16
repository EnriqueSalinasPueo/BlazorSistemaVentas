using BlazorSistemaVentas.Shared;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorSistemaVentas.Client.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpclient;
        private readonly ILogger<ProductService> _logger;
        public ProductService(HttpClient httpclient, ILogger<ProductService> logger)
        {
            _httpclient = httpclient;
            _logger = logger;
        }
        public async Task<IEnumerable<Product>> GetByCategory(int productCategoryId)
        {
            _logger.LogInformation($"INICIO - GetByCategory");

            IEnumerable<Product> list = await _httpclient.GetFromJsonAsync<IEnumerable<Product>>($"api/Product/getbycategory/{productCategoryId}");

            _logger.LogInformation($"FIN - GetByCategory respuesta: {list}");

            return list;
        }
    }
}
