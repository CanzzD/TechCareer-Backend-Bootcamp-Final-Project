using FinalProject.Entity;
namespace FinalProject.Data.Abstract{

    public interface ICommentRepository{
        IQueryable<Comment> Comments {get;}
        void CreateComment(Comment comment);
    }
}