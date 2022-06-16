using BlazorSistemaVentas.Shared;
using BlazorSistemaVentas_Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSistemaVentas.Server.Controllers
{
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
            _logger.LogInformation($"INICIO - Get");

            IEnumerable<Product> list = await _iProductRepository.GetByCategory(productCategoryId);

            _logger.LogInformation($"FIN - Get respuesta: {list}");

            return list;
        }
    }
}
