namespace FinalProject.Entity{
    public enum CategoryColors{
        primary,danger,warning,success,info
    }
    public class Category{
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryUrl { get; set; }
        public CategoryColors Color {get; set;}
        public List<Product> Products { get; set; } = new List<Product>();
        
    }
}