using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ECOMMERCE.DATA.Repositories
{
    public class OrderStatusesRepository : RepositoryBase<OrderStatuses, int>, IOrderStatusesRepository
    {
        public OrderStatusesRepository(DbContext dbDataContext) : base(dbDataContext)
        {

        }
    }

}
