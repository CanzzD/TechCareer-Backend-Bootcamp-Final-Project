namespace FinalProject.Entity{
    public class Tag{
        public int TagId { get; set; }
        public string? TagText { get; set; }
        public string? TagUrl { get; set; } 
        public List<Post> Posts { get; set; } = new List<Post>();
        
    }
}