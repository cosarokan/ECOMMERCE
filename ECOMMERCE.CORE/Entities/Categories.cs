using System;
using System.Collections.Generic;

namespace ECOMMERCE.CORE.Entities
{
    public class Categories : Entity<int>
    {
        public int CreatedById { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Users CreatedBy { get; set; }
        public virtual List<SubCategories> SubCategories { get; set; }
    }
}