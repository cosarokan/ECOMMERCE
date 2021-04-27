using System;
using System.Collections.Generic;

namespace ECOMMERCE.CORE.Entities
{
    public class ProductTypes : Entity<int>
    {
        public int CreatedById { get; set; }
        public int SubCategoryId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Users CreatedBy { get; set; }
        public virtual SubCategories SubCategory { get; set; }
        public virtual List<ProductProperties> ProductProperties { get; set; }
        public virtual List<BrandModels> BrandModels { get; set; }
    }
}