using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ECOMMERCE.DATA.Repositories
{
    public class CityRepository : RepositoryBase<City, int>, ICityRepository
    {
        public CityRepository(DbContext dbDataContext) : base(dbDataContext)
        {

        }
    }
}
