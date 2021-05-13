using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ECOMMERCE.DATA.Repositories
{
    public class ProductPropertyValuesRepository : RepositoryBase<ProductPropertyValues, int>, IProductPropertyValuesRepository
    {
        public ProductPropertyValuesRepository(DbContext dbDataContext) : base(dbDataContext)
        {

        }

        public List<ProductPropertyValues> GetAllByProductTypeCode(string productTypeCode)
        {
            var productPropertyValues = _dbDataContext.ProductPropertyValues;

            return null;
        }
    }
}
