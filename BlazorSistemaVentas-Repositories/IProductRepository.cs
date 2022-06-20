using BlazorSistemaVentas.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorSistemaVentas_Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetByCategory(int productCategoryId);
        Task<Product> GetDetails(int productId);
    }
}
