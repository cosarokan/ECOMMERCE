using System;
using System.Collections.Generic;

namespace ECOMMERCE.CORE.Entities
{
    public class ProductProperties : Entity<int>
    {
        public int ProductTypeId { get; set; }
        public int CreatedById { get; set; }
        public string Property { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsProduct { get; set; }

        public virtual ProductTypes ProductType { get; set; }
        public virtual Users CreatedBy { get; set; }
        public virtual List<ProductPropertyValues> ProductPropertyValues { get; set; }
    }
}