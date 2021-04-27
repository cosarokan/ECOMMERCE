using System;
using System.Collections.Generic;

namespace ECOMMERCE.CORE.Entities
{
    public class Orders : Entity<int>
    {
        public int PaymentTypeId { get; set; }
        public int CustomerId { get; set; }
        public int StatusId { get; set; }
        public int ApprovedById { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime ApprovedDate { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual Users ApprovedBy { get; set; }
        public virtual PaymentTypes PaymentType { get; set; }
        public virtual OrderStatuses Status { get; set; }
        public virtual List<OrderDetails> OrderDetails { get; set; }
    }
}