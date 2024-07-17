namespace FinalProject.Entity{
    public class Seller
    {
        public int SellerId { get; set; }
        public string? StoreName { get; set; }
        public string? Description { get; set; }
        public int UserId { get; set; } 
        public User User { get; set; } = null!;
        public List<Product> Products { get; set; }= new List<Product>();
    }
}