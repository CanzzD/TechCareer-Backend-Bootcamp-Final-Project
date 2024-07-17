using FinalProject.Entity;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Data.Concrete.EfCore
{
    public class SocialAppDbContext : DbContext
    {

        public SocialAppDbContext(DbContextOptions<SocialAppDbContext> options) : base(options) { }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<Review> Reviews => Set<Review>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<CartItem> CartItems => Set<CartItem>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();
        public DbSet<Seller> Sellers => Set<Seller>();
        public DbSet<ShoppingCart> ShoppingCarts => Set<ShoppingCart>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<User> Users => Set<User>();
    }
}