using System;
using System.Collections.Generic;

namespace ECOMMERCE.CORE.Entities
{
    public class Product : Entity<int>
    {
        public int BrandModelId { get; set; }
        public int CreatedById { get; set; }
        public string Title { get; set; }
        public string Weight { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public DateTime DateOfProduction { get; set; }
        public string ProductCode { get; set; }
        public string Description { get; set; }
        public string Currency { get; set; }
        public DateTime CreatedDate { get; set; }
        public int StockQuantity { get; set; }

        public virtual Users CreatedBy { get; set; }
        public virtual BrandModels BrandModel { get; set; }
        public virtual List<ProductImages> ProductImages { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<ProductPropertyValues> ProductPropertyValues { get; set; }
        public virtual List<OrderDetails> OrderDetails { get; set; }
        public virtual List<ShoppingCart> ShoppingCarts { get; set; }
    }
}
