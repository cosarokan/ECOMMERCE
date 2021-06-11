namespace ECOMMERCE.WEBUI.Models
{
    public class ShoppingCartItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get { return Price * Quantity; } }
    }
}
