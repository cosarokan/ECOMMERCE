using ECOMMERCE.CORE.Entities;
using System.Collections.Generic;

namespace ECOMMERCE.CORE.Repositories
{
    public interface IProductTypesRepository : IRepository<ProductTypes, int>
    {
        List<ProductTypes> GetAllBySubCategory(string subCategoryCode);
    }
}
