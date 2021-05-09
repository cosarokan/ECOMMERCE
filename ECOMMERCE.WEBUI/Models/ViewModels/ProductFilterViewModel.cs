using System.Collections.Generic;

namespace ECOMMERCE.WEBUI.Models.ViewModels
{
    public class ProductFilterViewModel
    {
        public List<ProductModel> Products { get; set; }
        public List<CategoryModel> Categories { get; set; }
        public List<BrandQuantityModel> Brands { get; set; }
    }
}
