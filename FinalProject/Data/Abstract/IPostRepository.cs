using FinalProject.Entity;

namespace FinalProject.Data.Abstract{
    public interface IPostRepository{
        IQueryable<Post> Posts {get;}

        void CreatePost(Post post);
    }
}