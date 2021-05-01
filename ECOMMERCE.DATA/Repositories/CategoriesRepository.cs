using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ECOMMERCE.DATA.Repositories
{
    public class CategoriesRepository : RepositoryBase<Categories, int>, ICategoriesRepository
    {
        public CategoriesRepository(DbContext dbDataContext) : base(dbDataContext)
        {

        }

        public List<Categories> GetAllWithSubCategories()
        {
            return this._dbDataContext.Categories.Include(x=>x.SubCategories).ToList();
        }
    }
}
