using ECOMMERCE.CORE.Entities;
using System.Collections.Generic;

namespace ECOMMERCE.CORE.Repositories
{
    public interface IProductRepository : IRepository<Product, int>
    {
        List<Product> GetAllWithBrand();

        List<Product> GetAllWithBrandByCategoryCode(string categoryCode);

        List<Product> GetAllWithBrandBySubCategoryCode(string categoryCode, string subCategoryCode);

        List<Product> GetAllWithBrandByProductType(string categoryCode, string subCategoryCode, string productType);

        Product GetByIdWithDetails(int productId);
    }
}
