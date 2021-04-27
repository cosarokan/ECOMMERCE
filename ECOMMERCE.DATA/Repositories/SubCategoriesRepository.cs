using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ECOMMERCE.DATA.Repositories
{
    public class SubCategoriesRepository : RepositoryBase<SubCategories, int>, ISubCategoriesRepository
    {
        public SubCategoriesRepository(DbContext dbDataContext) : base(dbDataContext)
        {

        }
    }
}
