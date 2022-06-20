using BlazorSistemaVentas.Shared;
using BlazorSistemaVentas_Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorSistemaVentas.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _iProductRepository;

        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductRepository iProductRepository, ILogger<ProductController> logger)
        {
            _iProductRepository = iProductRepository;
            _logger = logger;
        }

        [HttpGet("getbycategory/{productCategoryId}")]
        public async Task<IEnumerable<Product>> GetByCategory(int productCategoryId)
        {
            _logger.LogInformation($"INICIO - GetByCategory");

            var request = await _iProductRepository.GetByCategory(productCategoryId);

            _logger.LogInformation($"FIN - GetByCategory respuesta: {request}");

            return request;
        }

        [HttpGet("{id}")]
        public async Task<Product> GetDetails(int id)
        {
            _logger.LogInformation($"INICIO - GetDetails");

            var request = await _iProductRepository.GetDetails(id);

            _logger.LogInformation($"FIN - GetDetails respuesta: {request}");

            return request;
        }
    }
}
