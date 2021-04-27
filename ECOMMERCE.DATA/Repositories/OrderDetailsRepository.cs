using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ECOMMERCE.DATA.Repositories
{
    public class OrderDetailsRepository : RepositoryBase<OrderDetails, int>, IOrderDetailsRepository
    {
        public OrderDetailsRepository(DbContext dbDataContext) : base(dbDataContext)
        {

        }
    }
}
