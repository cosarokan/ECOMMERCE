using System.Collections.Generic;

namespace ECOMMERCE.CORE.Entities
{
    public class PaymentTypes : Entity<int>
    {
        public string PaymentType { get; set; }
        public virtual List<Orders> Orders { get; set; }
    }
}