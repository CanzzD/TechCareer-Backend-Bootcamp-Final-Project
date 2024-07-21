namespace FinalProject.Entity
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? ProductTitle { get; set; }
        public string? ProductCategory { get; set; }
        public int ProductPrice { get; set; }
        public string? ProductDescription { get; set; }
        public string? ProductUrl { get; set; }
        public string? Image { get; set; }
        public DateTime ProductPublishedOn { get; set; }
        public bool IsActive { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public List<Category> Categories { get; set; } = new List<Category>();
        public List<Like> Likes { get; set; } = new List<Like>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}