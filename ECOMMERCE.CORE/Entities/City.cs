using System.Collections.Generic;

namespace ECOMMERCE.CORE.Entities
{
    public class City : Entity<int>
    {
        public string Name { get; set; }

        public virtual List<District> Districts { get; set; }

        public virtual List<Customers> Customers { get; set; }
    }
}