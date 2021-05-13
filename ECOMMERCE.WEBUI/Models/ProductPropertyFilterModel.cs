using System.Collections.Generic;

namespace ECOMMERCE.WEBUI.Models
{
    public class ProductPropertyFilterModel
    {
        public int Id { get; set; }
        public string Property { get; set; }
        public List<string> Values { get; set; }
    }
}