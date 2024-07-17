using FinalProject.Entity;

namespace FinalProject.Data.Abstract{
    public interface ICategoryRepository{
        IQueryable<Category> Categories {get;}

        void CreateCategory(Category category);
    }
}