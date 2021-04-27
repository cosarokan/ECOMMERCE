namespace ECOMMERCE.CORE.Entities
{
    public class OrderDetails : Entity<int>
    {
        public int OrderId { get; set; }
        public int  ProductId { get; set; }
        public int Count { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
