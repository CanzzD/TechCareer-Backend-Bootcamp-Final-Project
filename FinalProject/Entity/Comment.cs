namespace FinalProject.Entity
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string? CommentText { get; set; }
        public DateTime CommentPublishedOn { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}