namespace FinalProject.Entity{
    public class Like{
        public int LikeId { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; } = null!;
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        
    }
}