using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ECOMMERCE.DATA.Repositories
{
    public class ShoppingCartRepository : RepositoryBase<ShoppingCart, int>, IShoppingCartRepository
    {
        public ShoppingCartRepository(DbContext dbDataContext) : base(dbDataContext)
        {

        }
    }
}
