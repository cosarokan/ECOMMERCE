using System;
using System.Collections.Generic;

namespace ECOMMERCE.CORE.Entities
{
    public class SubCategories : Entity<int>
    {
        public int CategoryId { get; set; }
        public int CreatedById { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Categories Category { get; set; }
        public virtual Users CreatedBy { get; set; }
        public virtual List<ProductTypes> ProductTypes { get; set; }
    }
}