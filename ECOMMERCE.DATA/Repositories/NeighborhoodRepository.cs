using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ECOMMERCE.DATA.Repositories
{
    public class NeighborhoodRepository : RepositoryBase<Neighborhood, int>, INeighborhoodRepository
    {
        public NeighborhoodRepository(DbContext dbDataContext) : base(dbDataContext)
        {

        }
    }
}
