using FinalProject.Entity;

namespace FinalProject.Data.Abstract{
    public interface IUserRepository{
        IQueryable<User> Users {get;}
        void CreateUser(User user);
    }
}