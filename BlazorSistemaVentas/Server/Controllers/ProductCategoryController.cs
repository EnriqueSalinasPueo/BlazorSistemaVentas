using BlazorSistemaVentas.Shared;
using BlazorSistemaVentas_Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorSistemaVentas.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryRepositiry _iProductCategoryRepository;

        private readonly ILogger<ProductCategoryController> _logger;

        public ProductCategoryController(IProductCategoryRepositiry iProductCategoryRepository, ILogger<ProductCategoryController> logger)
        {
            _iProductCategoryRepository = iProductCategoryRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductCategory>> Get()
        {
            _logger.LogInformation("INICIO - Controller ProductCategoryController Get");

            IEnumerable<ProductCategory> list = await _iProductCategoryRepository.GetAll();

            _logger.LogInformation("FIN - Controller ProductCategoryController Get list: " + list);

            return list;
        }
    }

}
