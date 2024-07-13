using FinalProject.Data.Abstract;
using FinalProject.Data.Concrete.EfCore;
using FinalProject.Entity;

namespace FinalProject.Data.Concrete
{
    public class EfPostRepostory : IPostRepository
    {

        private readonly SocialAppDbContext _context;
        public EfPostRepostory(SocialAppDbContext context)
        {
            _context = context;
        }
        public IQueryable<Post> Posts => _context.Posts;

        public void CreatePost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }
    }
}