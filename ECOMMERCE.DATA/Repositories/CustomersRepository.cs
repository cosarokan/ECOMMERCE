using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ECOMMERCE.DATA.Repositories
{
    public class CustomersRepository : RepositoryBase<Customers, int>, ICustomersRepository
    {
        public CustomersRepository(DbContext dbDataContext) : base(dbDataContext)
        {

        }

        public Customers Login(string emailAddress, string password)
        {
            Customers customer = _dbDataContext.Customers
                .Include(x => x.Orders)
                .Include(x => x.Orders).ThenInclude(x=>x.OrderDetails)
                .SingleOrDefault(x => x.Email == emailAddress && x.Password == password);

            return customer;
        }
    }
}
