using System.Collections.Generic;

namespace ECOMMERCE.CORE.Entities
{
    public class OrderStatuses : Entity<int>
    {
        public string Status { get; set; }
        public virtual List<Orders> Orders { get; set; }
    }
}