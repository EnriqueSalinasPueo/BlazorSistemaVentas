using BlazorSistemaVentas.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSistemaVentas_Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetByCategory(int productCategoryId);
    }
}
