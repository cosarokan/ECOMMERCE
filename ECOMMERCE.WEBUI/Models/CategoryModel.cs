using System.Collections.Generic;

namespace ECOMMERCE.WEBUI.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public List<SubCategoryModel> SubCategories { get; set; }
    }
}