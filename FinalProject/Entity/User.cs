namespace FinalProject.Entity
{
    public class User
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Password { get; set; }
        public bool IsSeller { get; set; }
        public string? Email { get; set; }
        public Seller Seller { get; set; } = null!;
        public ShoppingCart ShoppingCart { get; set; } = null!;
        public List<Order> Orders { get; set; } = new List<Order>();

    }
}