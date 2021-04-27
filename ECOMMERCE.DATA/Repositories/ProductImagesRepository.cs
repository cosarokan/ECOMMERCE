using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ECOMMERCE.DATA.Repositories
{
    public class ProductImagesRepository : RepositoryBase<ProductImages, int>, IProductImagesRepository
    {
        public ProductImagesRepository(DbContext dbDataContext) : base(dbDataContext)
        {

        }
    }
}
