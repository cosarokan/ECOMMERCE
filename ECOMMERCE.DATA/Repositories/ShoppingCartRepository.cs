using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ECOMMERCE.DATA.Repositories
{
    public class ShoppingCartRepository : RepositoryBase<ShoppingCart, int>, IShoppingCartRepository
    {
        public ShoppingCartRepository(DbContext dbDataContext) : base(dbDataContext)
        {

        }

        public List<ShoppingCart> GetAllByCustomerId(int customerId)
        {
            List<ShoppingCart> shoppingCarts = _dbDataContext.ShoppingCart
                .Include(x => x.Product)
                .Include(x => x.Product.BrandModel)
                .Include(x => x.Product.BrandModel.Brand)
                .Where(x => x.CustomerId == customerId).ToList();

            return shoppingCarts;
        }
    }
}
