using System.Collections.Generic;

namespace ECOMMERCE.WEBUI.Models
{
    public class HomeViewModel
    {
        public List<CategoryViewModel> Categories { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}