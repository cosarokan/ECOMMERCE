using ECOMMERCE.CORE.Entities;
using System.Collections.Generic;

namespace ECOMMERCE.CORE.Repositories
{
    public interface IShoppingCartRepository : IRepository<ShoppingCart, int>
    {
        /// <summary>
        /// Müşterinin sepetini getirir.
        /// </summary>
        /// <returns></returns>
        List<ShoppingCart> GetAllByCustomerId(int customerId);
    }
}
