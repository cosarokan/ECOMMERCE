using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ECOMMERCE.DATA.Repositories
{
    public class ProductPropertiesRepository : RepositoryBase<ProductProperties, int>, IProductPropertiesRepository
    {
        public ProductPropertiesRepository(DbContext dbDataContext) : base(dbDataContext)
        {

        }
    }
}
