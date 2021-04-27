using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ECOMMERCE.DATA.Repositories
{
    public class DistrictRepository : RepositoryBase<District, int>, IDistrictRepository
    {
        public DistrictRepository(DbContext dbDataContext) : base(dbDataContext)
        {

        }
    }
}
