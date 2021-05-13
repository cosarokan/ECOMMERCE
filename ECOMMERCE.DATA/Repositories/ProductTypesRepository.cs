using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ECOMMERCE.DATA.Repositories
{
    public class ProductTypesRepository : RepositoryBase<ProductTypes, int>, IProductTypesRepository
    {
        public ProductTypesRepository(DbContext dbDataContext) : base(dbDataContext)
        {

        }

        public List<ProductTypes> GetAllBySubCategory(string subCategoryCode)
        {
            return _dbDataContext.ProductTypes
                .Include(x => x.SubCategory)
                .Include(x => x.SubCategory.Category)
                .Where(x => x.SubCategory.Code == subCategoryCode).ToList();
        }
    }
}
