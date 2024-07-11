namespace FinalProject.Entity{
    public class User {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserImage { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public List<Post> Posts { get; set; } = new List<Post>();
        public List<Event> Events { get; set; } = new List<Event>();        
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}