using System.Collections.Generic;

namespace ECOMMERCE.WEBUI.Models.ViewModels
{
    public class DetailViewModel
    {
        public List<CategoryModel> Categories { get; set; }
        public ProductModel Product { get; set; }
    }
}