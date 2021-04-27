using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ECOMMERCE.DATA.Repositories
{
    public class BrandRepository: RepositoryBase<Brands, int>, IBrandRepository
    {
        public BrandRepository(DbContext dbDataContext) : base(dbDataContext)
        {

        }
    }
}
