using System;

namespace ECOMMERCE.CORE.Entities
{
    public class Sliders : Entity<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string LinkTitle { get; set; }
        public string Image { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}