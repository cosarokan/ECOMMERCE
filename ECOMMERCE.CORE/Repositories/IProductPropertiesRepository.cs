using ECOMMERCE.CORE.Entities;
using System.Collections.Generic;

namespace ECOMMERCE.CORE.Repositories
{
    public interface IProductPropertiesRepository : IRepository<ProductProperties, int>
    {
        List<ProductProperties> GetAllByProductTypeCode(string productTypeCode);
    }
}
