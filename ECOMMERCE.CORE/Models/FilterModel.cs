using System.Collections.Generic;

namespace ECOMMERCE.CORE.Models
{
    public class FilterModel
    {
        public List<int> BrandIdList { get; set; }
        public decimal? PriceMinValue { get; set; }
        public decimal? PriceMaxValue { get; set; }
        public List<KeyValuePair<int, string>> ProductProperties { get; set; }
    }
}
