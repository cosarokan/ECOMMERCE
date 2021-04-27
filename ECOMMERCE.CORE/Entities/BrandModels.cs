using System;
using System.Collections.Generic;

namespace ECOMMERCE.CORE.Entities
{
    public class BrandModels : Entity<int>
    {
        public int CreatedById { get; set; }
        public int BrandId { get; set; }
        public int ProductTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Users CreatedBy { get; set; }
        public virtual Brands Brand { get; set; }
        public virtual ProductTypes ProductType { get; set; }
        public virtual List<Product> Products { get; set; }
        public virtual List<ProductPropertyValues> ProductPropertyValues { get; set; }
    }
}