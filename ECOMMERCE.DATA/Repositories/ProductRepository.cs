using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ECOMMERCE.DATA.Repositories
{
    public class ProductRepository : RepositoryBase<Product, int>, IProductRepository
    {
        public ProductRepository(DbContext dbDataContext) : base(dbDataContext)
        {

        }
    }
}
