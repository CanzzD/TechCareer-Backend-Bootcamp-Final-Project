namespace FinalProject.Entity
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductCategory { get; set; }
        public int ProductPrice { get; set; }
        public string? ProductDescription { get; set; }
        public string? ProductUrl { get; set; }
        public string? Image { get; set; }
        public int StockQuantity { get; set; }
        public int SellerId { get; set; }
        public Seller Seller { get; set; } = null!;
        public List<Category> Categories { get; set; } = new List<Category>();
        public List<Review> Reviews { get; set; } = new List<Review>();
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}