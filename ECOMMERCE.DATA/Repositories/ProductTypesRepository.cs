using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECOMMERCE.DATA.Repositories
{
    public class ProductTypesRepository : RepositoryBase<ProductTypes, int>, IProductTypesRepository
    {
        public ProductTypesRepository(DbContext dbDataContext) : base(dbDataContext)
        {

        }
    }

}
