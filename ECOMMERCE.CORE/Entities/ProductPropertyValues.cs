using System;

namespace ECOMMERCE.CORE.Entities
{
    public class ProductPropertyValues : Entity<int>
    {
        public int ValueReferenceModelId { get; set; }
        public int CreatedById { get; set; }
        public int BrandModelId { get; set; }
        public int ProductPropertyId { get; set; }
        public string Value { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual BrandModels ValueReferenceModel { get; set; }
        public virtual Users CreatedBy { get; set; }
        public virtual BrandModels BrandModel { get; set; }
        public virtual ProductProperties ProductProperty { get; set; }
    }
}