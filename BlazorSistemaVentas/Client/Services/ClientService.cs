using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorSistemaVentas.Client.Services
{
    public class ClientService : IClientService
    {
        private readonly HttpClient _httpclient;
        private readonly ILogger<ClientService> _logger;

        public ClientService(HttpClient httpclient, ILogger<ClientService> logger)
        {
            _httpclient = httpclient;
            _logger = logger;
        }
        public async Task<IEnumerable<BlazorSistemaVentas.Shared.Client>> GetAllClients()
        {
            _logger.LogInformation($"INICIO - GetAllClients");

            var request = await _httpclient.GetFromJsonAsync<IEnumerable<BlazorSistemaVentas.Shared.Client>>($"api/Client");

            _logger.LogInformation($"FIN - GetAllClients request: {request}");

            return request;
        }
    }
}
