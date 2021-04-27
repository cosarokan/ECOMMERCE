using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ECOMMERCE.DATA.Repositories
{
    public class CategoriesRepository : RepositoryBase<Categories, int>, ICategoriesRepository
    {
        public CategoriesRepository(DbContext dbDataContext) : base(dbDataContext)
        {

        }
    }
}
