using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSistemaVentas.Client.Services
{
    public interface IClientService
    {
        Task<IEnumerable<BlazorSistemaVentas.Shared.Client>> GetAllClients();
    }
}
