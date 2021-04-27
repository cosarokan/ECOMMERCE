using System;
using System.Collections.Generic;

namespace ECOMMERCE.CORE.Entities
{
    public class Customers : Entity<int>
    {
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string GSM1 { get; set; }
        public string GSM2 { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual City City { get; set; }
        public virtual District District { get; set; }
        public virtual List<ShoppingCart> ShoppingCarts { get; set; }
        public virtual List<Orders> Orders { get; set; }
        public virtual List<Comment> Comments { get; set; }
    }
}