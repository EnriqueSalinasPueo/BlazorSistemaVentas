using BlazorSistemaVentas.Shared;
using BlazorSistemaVentas_Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSistemaVentas.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _iOrderRepository;

        private readonly ILogger<OrderController> _logger;

        public OrderController(IOrderRepository iOrderRepository, ILogger<OrderController> logger)
        {
            _iOrderRepository = iOrderRepository;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Order order)
        {
            _logger.LogInformation($"INICIO - Post order: {order}");

            if(order == null)
            {
                return BadRequest();
            }
            if (order.OrderNumber == 0)
            {
                ModelState.AddModelError("OrderNumber","Order numbar can`t be empty");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var request = await _iOrderRepository.InserOrder(order);

            _logger.LogInformation($"FIN - Post request: {request}");

            return NoContent();

        }

        [HttpGet("GetNextNumber")]
        public async Task<int> GetNextNumber()
        {
            _logger.LogInformation($"INICIO - GetNextNumber");

            var request = await _iOrderRepository.GetNextNumber();

            _logger.LogInformation($"FIN - GetNextNumber request: {request}");

            return request;

        }
    }
}
