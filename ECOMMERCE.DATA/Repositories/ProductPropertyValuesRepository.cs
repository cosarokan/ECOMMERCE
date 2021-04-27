using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ECOMMERCE.DATA.Repositories
{
    public class ProductPropertyValuesRepository : RepositoryBase<ProductPropertyValues, int>, IProductPropertyValuesRepository
    {
        public ProductPropertyValuesRepository(DbContext dbDataContext) : base(dbDataContext)
        {

        }
    }
}
