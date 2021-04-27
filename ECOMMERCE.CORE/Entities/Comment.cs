using System;

namespace ECOMMERCE.CORE.Entities
{
    public class Comment : Entity<int>
    {
        public int ApprovedById { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public string CommentText { get; set; }
        public string Title { get; set; }
        public DateTime CommentDate { get; set; }
        public bool IsApproved { get; set; }
        public DateTime ApprovedDate { get; set; }

        public virtual Orders ApprovedBy { get; set; }
        public virtual Customers Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}