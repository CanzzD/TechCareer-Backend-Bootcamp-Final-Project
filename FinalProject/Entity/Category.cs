namespace FinalProject.Entity{
    public class Category{
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryUrl { get; set; } 
        public List<Product> Products { get; set; } = new List<Product>();
        
    }
}