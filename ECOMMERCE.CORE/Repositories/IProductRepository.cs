using ECOMMERCE.CORE.Entities;
using System.Collections.Generic;

namespace ECOMMERCE.CORE.Repositories
{
    public interface IProductRepository : IRepository<Product, int>
    {
        List<Product> GetAllWithBrand();
    }
}
