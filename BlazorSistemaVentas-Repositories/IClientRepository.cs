using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorSistemaVentas.Shared;

namespace BlazorSistemaVentas_Repositories
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAllClients();
    }
}
