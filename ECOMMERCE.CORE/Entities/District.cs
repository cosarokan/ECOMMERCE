using System.Collections.Generic;

namespace ECOMMERCE.CORE.Entities
{
    public class District : Entity<int>
    {
        public int CityId { get; set; }
        public string Name { get; set; }

        public virtual City City { get; set; }
        public virtual List<Neighborhood> Neighborhoods { get; set; }
        public virtual List<Customers> Customers { get; set; }
    }
}
