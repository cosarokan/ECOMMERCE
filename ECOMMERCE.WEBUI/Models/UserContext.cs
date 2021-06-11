using System.Collections.Generic;

namespace ECOMMERCE.WEBUI.Models
{
    public class UserContext
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<int> OrderProductIds { get; set; }
    }
}
