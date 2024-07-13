using FinalProject.Entity;

namespace FinalProject.Data.Abstract{
    public interface ITagRepository{
        IQueryable<Tag> Tags {get;}

        void CreateTag(Tag tag);
    }
}