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
        int GetCommentId();
    }
}
