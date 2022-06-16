using BlazorSistemaVentas.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorSistemaVentas_Repositories
{
    public interface IProductCategoryRepositiry
    {
        Task<IEnumerable<ProductCategory>> GetAll();
    }
}
