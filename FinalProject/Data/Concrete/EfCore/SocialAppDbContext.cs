using FinalProject.Entity;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Data.Concrete.EfCore{
    public class SocialAppDbContext:DbContext{

        public SocialAppDbContext(DbContextOptions<SocialAppDbContext> options):base(options){}

        public DbSet<Post> Posts => Set<Post>();
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<Like> Likes => Set<Like>();
        public DbSet<Tag> Tags => Set<Tag>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Event> Events => Set<Event>();
        public DbSet<EventParticipant> EventParticipants => Set<EventParticipant>();

        
    }
}