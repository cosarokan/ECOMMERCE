using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ECOMMERCE.DATA.Repositories
{
    public class CustomersRepository : RepositoryBase<Customers, int>, ICustomersRepository
    {
        public CustomersRepository(DbContext dbDataContext) : base(dbDataContext)
        {

        }
    }
}
