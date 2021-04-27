using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ECOMMERCE.DATA.Repositories
{
    public class BrandModelRepository: RepositoryBase<BrandModels, int>, IBrandModelRepository
    {
        public BrandModelRepository(DbContext dbDataContext) : base(dbDataContext)
        {

        }
    }
}
