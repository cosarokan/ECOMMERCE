using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ECOMMERCE.DATA.Repositories
{
    public class ProductRepository : RepositoryBase<Product, int>, IProductRepository
    {
        public ProductRepository(DbContext dbDataContext) : base(dbDataContext)
        {

        }

        public List<Product> GetAllWithBrand()
        {
            return _dbDataContext.Products.Include(x => x.BrandModel).Include(x => x.BrandModel.Brand).ToList();
        }
    }
}
