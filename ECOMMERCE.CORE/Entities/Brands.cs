using System;
using System.Collections.Generic;

namespace ECOMMERCE.CORE.Entities
{
    public class Brands : Entity<int>
    {
        public int CreatedById { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Users CreatedBy { get; set; }
        public virtual List<BrandModels> Models { get; set; }
    }
}