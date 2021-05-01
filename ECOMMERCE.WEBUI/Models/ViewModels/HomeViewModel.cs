using System.Collections.Generic;

namespace ECOMMERCE.WEBUI.Models.ViewModels
{
    public class HomeViewModel
    {
        public List<CategoryModel> Categories { get; set; }
        public List<ProductModel> Products { get; set; }
        public List<SliderModel> Sliders { get; set; }
    }
}