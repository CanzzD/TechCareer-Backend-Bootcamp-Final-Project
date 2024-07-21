using FinalProject.Data.Abstract;
using FinalProject.Data.Concrete.EfCore;
using FinalProject.Entity;

namespace FinalProject.Data.Concrete{

    public class EfCommentRepository : ICommentRepository
    {
        private readonly SocialAppDbContext _context;

        public EfCommentRepository(SocialAppDbContext context){
            _context = context;
        }
        public IQueryable<Comment> Comments => _context.Comments;

        public void CreateComment(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }
    }
}