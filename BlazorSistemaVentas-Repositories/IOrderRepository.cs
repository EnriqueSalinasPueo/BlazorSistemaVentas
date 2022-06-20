using BlazorSistemaVentas.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorSistemaVentas_Repositories
{
    public interface IOrderRepository
    {
        Task<bool> InserOrder(Order order);
        Task<int> GetNextNumber();
        Task<int> GetNextId();
        Task<IEnumerable<Order>> GetAll();
        Task<Order> GetDetailsId(int id);
    }
}
