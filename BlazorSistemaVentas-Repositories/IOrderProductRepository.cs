using BlazorSistemaVentas.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorSistemaVentas_Repositories
{
    public interface IOrderProductRepository
    {
        Task<bool> InserOrderProduct(int orderId, Product product);
        Task<IEnumerable<Product>> GetByOrder(int orderId); 
        Task<bool> DeleteOrderProductByOrder(int orderId);
    }
}
