using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ECOMMERCE.DATA.Repositories
{
    public class SubCategoriesRepository : RepositoryBase<SubCategories, int>, ISubCategoriesRepository
    {
        public SubCategoriesRepository(DbContext dbDataContext) : base(dbDataContext)
        {

        }

        public List<SubCategories> GetAllWithCategories()
        {
            return _dbDataContext.SubCategories.Include(x => x.Category).ToList();
        }
    }
}
