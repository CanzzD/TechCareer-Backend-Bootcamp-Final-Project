
namespace FinalProject.Entity{
public class ShoppingCart
    {
        public int ShoppingCartId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}