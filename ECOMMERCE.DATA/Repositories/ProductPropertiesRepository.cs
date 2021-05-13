using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ECOMMERCE.DATA.Repositories
{
    public class ProductPropertiesRepository : RepositoryBase<ProductProperties, int>, IProductPropertiesRepository
    {
        public ProductPropertiesRepository(DbContext dbDataContext) : base(dbDataContext)
        {

        }

        public List<ProductProperties> GetAllByProductTypeCode(string productTypeCode)
        {
            return _dbDataContext.ProductProperties
                .Include(x => x.ProductPropertyValues)
                .Include(x => x.ProductType)
                .Where(x => x.ProductType.Code == productTypeCode)
                .ToList();
        }
    }
}
