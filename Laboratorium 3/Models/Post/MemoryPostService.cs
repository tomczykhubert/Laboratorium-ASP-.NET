using Data.Entities.Post;
using Microsoft.EntityFrameworkCore;

namespace Laboratorium_3.Models
{
    public class MemoryPostService : IPostService
    {
        private Dictionary<int, Post> _posts = new Dictionary<int, Post>();
        private Dictionary<int, Comment> _comments = new Dictionary<int, Comment>();

        int id = 1;
        int commentId = 1;

        private IDateTimeProvider _dateTimeProvider;

        public MemoryPostService(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        public PagingList<Post> FindPage(int page, int size, List<Post> posts)
        {
            return PagingList<Post>.Create(
                (p, s) => posts.OrderBy(c => c.PublicationDate).Skip((p - 1) * s).Take(s)
                , page, size, posts.Count()
            );
        }

        public int Add(Post model)
        {
            model.Id = id;
            _posts.Add(id, model);
            id++;
            return model.Id;
        }

        public void Delete(int id)
        {
            _posts.Remove(id);
        }

        public List<Post> FindAll()
        {
            return _posts.Values.ToList();
        }

        public Post? FindById(int id)
        {
            return _posts.ContainsKey(id) ? _posts[id] : null;

        }

        public List<Post> FindByTag(int tagId)
        {
            return _posts.Values.Where(o => o.TagId == tagId).ToList();
        }

        public void Update(Post model)
        {
            if (_posts.ContainsKey(model.Id))
            {
                model.PublicationDate = _posts[model.Id].PublicationDate;
                _posts[model.Id] = model;
            }

        }

        public void AddComment(Comment model)
        {
            model.CommentId = commentId;
            _comments.Add(model.CommentId, model);
            commentId++;
        }

        public void DeleteComment(int id)
        {
            if (_comments.ContainsKey(id))
                _comments.Remove(id);
        }
    }
}
