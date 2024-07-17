using FinalProject.Data.Abstract;
using FinalProject.Data.Concrete.EfCore;
using FinalProject.Entity;

namespace FinalProject.Data.Concrete
{
    public class EfCategoryRepository : ICategoryRepository
    {

        private readonly SocialAppDbContext _context;
        public EfCategoryRepository(SocialAppDbContext context)
        {
            _context = context;
        }
        public IQueryable<Category> Categories => _context.Categories;

        public void CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChangesAsync();
        }
    }
}