namespace FinalProject.Entity{
    public class Like{
        public int LikeId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        
    }
}