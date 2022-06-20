using BlazorSistemaVentas.Shared;
using System.Threading.Tasks;

namespace BlazorSistemaVentas_Repositories
{
    public interface IOrderProductRepository
    {
        Task<bool> InserOrderProduct(int orderId, Product product);
    }
}
