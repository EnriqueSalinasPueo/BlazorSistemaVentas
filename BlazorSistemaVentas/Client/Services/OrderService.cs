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
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpclient;
        private readonly ILogger<OrderService> _logger;
        public OrderService(HttpClient httpclient, ILogger<OrderService> logger)
        {
            _httpclient = httpclient;
            _logger = logger;
        }

        public async Task<int> GetNextNumber()
        {
            _logger.LogInformation($"INICIO - GetNextNumber");

            var result = await _httpclient.GetFromJsonAsync<int>($"api/order/GetNextNumber");

            _logger.LogInformation($"FIN - GetNextNumber result; {result}");

            return result;
        }

        public async Task SaveOrder(Order order)
        {
            _logger.LogInformation($"INICIO - SaveOrder");

            if (order.Id == 0)
            {
                await _httpclient.PostAsJsonAsync<Order>($"api/order/", order);
            }
            else
            {

            }

            _logger.LogInformation($"FIN - SaveOrder");

        }
    }
}
