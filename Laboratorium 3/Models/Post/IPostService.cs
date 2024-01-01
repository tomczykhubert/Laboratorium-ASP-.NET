using Data.Entities.Post;

namespace Laboratorium_3.Models
{
    public interface IPostService
    {
        int Add(Post model);
        Post? FindById(int id);
        List<Post> FindAll();
        void Delete(int id);
        void Update(Post model);
        void AddComment(Comment comment);
        void DeleteComment(int id);
        List<Post> FindByTag(int tagId);
        PagingList<Post> FindPage(int page, int size, List<Post> posts);
    }
}
