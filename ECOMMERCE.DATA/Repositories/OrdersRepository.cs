using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ECOMMERCE.DATA.Repositories
{
    public class OrdersRepository : RepositoryBase<Orders, int>, IOrdersRepository
    {
        public OrdersRepository(DbContext dbDataContext) : base(dbDataContext)
        {

        }
    }
}
