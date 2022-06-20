using BlazorSistemaVentas.Shared;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
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

            var request = await _httpclient.GetFromJsonAsync<IEnumerable<Product>>($"api/Product/getbycategory/{productCategoryId}");

            _logger.LogInformation($"FIN - GetByCategory respuesta: {request}");

            return request;
        }

        public async Task<Product> GetDetails(int id)
        {
            _logger.LogInformation($"INICIO - GetDetails");

            var request = await _httpclient.GetFromJsonAsync<Product>($"api/Product/{id}");

            _logger.LogInformation($"FIN - GetDetails respuesta: {request}");

            return request;
        }
    }
}
