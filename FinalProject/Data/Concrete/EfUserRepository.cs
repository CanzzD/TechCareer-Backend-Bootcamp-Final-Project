using FinalProject.Data.Abstract;
using FinalProject.Data.Concrete.EfCore;
using FinalProject.Entity;

namespace FinalProject.Data.Concrete{
    public class EfUserRepository : IUserRepository
    {
        private readonly SocialAppDbContext _context;

        public EfUserRepository(SocialAppDbContext context){
            _context = context;
        }
        public IQueryable<User> Users => _context.Users;

        public void CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}