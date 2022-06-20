using BlazorSistemaVentas.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSistemaVentas_Repositories
{
    public interface IOrderRepository
    {
        Task<bool> InserOrder(Order order);
        Task<int> GetNextNumber();
        Task<int> GetNextId();
    }
}
