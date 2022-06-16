using BlazorSistemaVentas.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorSistemaVentas_Repositories
{
    public interface IProductCategoryRepository
    {
        Task<IEnumerable<ProductCategory>> GetAll();
    }
}
