using System.Collections.Generic;

namespace ECOMMERCE.WEBUI.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string CategoryCode { get; set; }
        public string SubCategoryCode { get; set; }
        public string ProductTypeCode { get; set; }
        public string ProductCode { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public List<ProductPropertyModel> ProductProperties { get; set; }
        public List<ProductCommentModel> Comments { get; set; }
    }
}
