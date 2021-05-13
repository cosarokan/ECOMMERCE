using ECOMMERCE.CORE.Entities;
using System.Collections.Generic;

namespace ECOMMERCE.CORE.Repositories
{
    public interface IProductPropertyValuesRepository : IRepository<ProductPropertyValues, int>
    {
        List<ProductPropertyValues> GetAllByProductTypeCode(string productTypeCode);
    }
}
