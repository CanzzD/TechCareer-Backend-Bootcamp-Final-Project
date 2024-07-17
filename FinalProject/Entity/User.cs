namespace FinalProject.Entity{
    public class User {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? UserImage { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public List<Event> Events { get; set; } = new List<Event>();        
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}