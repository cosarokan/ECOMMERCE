using System;

namespace ECOMMERCE.CORE.Entities
{
    public class ProductImages : Entity<int>
    {
        public int CreatedById { get; set; }
        public int ProductId { get; set; }
        public string Thumbnail { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Users CreatedBy { get; set; }
        public virtual Product Product { get; set; }
    }
}