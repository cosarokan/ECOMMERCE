using System;

namespace ECOMMERCE.CORE.Entities
{
    public class ShoppingCart : Entity<int>
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime AddDate { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}