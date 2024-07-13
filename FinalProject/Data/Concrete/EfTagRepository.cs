using FinalProject.Data.Abstract;
using FinalProject.Data.Concrete.EfCore;
using FinalProject.Entity;

namespace FinalProject.Data.Concrete
{
    public class EfTagRepostory : ITagRepository
    {

        private readonly SocialAppDbContext _context;
        public EfTagRepostory(SocialAppDbContext context)
        {
            _context = context;
        }
        public IQueryable<Tag> Tags => _context.Tags;


        public void CreateTag(Tag tag)
        {
            _context.Tags.Add(tag);
            _context.SaveChanges();
        }
    }
}