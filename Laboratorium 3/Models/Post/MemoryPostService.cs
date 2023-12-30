using Data.Entities.Post;

namespace Laboratorium_3.Models
{
    public class MemoryPostService : IPostService
    {
        private Dictionary<int, Post> _items = new Dictionary<int, Post>();

        private IDateTimeProvider _dateTimeProvider;

        public MemoryPostService(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        public int Add(Post item)
        {
            int id = _items.Keys.Count != 0 ? _items.Keys.Max() : 0;
            item.Id = id + 1;
            item.PublicationDate = _dateTimeProvider.dateNow();
            _items.Add(item.Id, item);
            return item.Id;
        }

        public void AddComment(Comment comment)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            _items.Remove(id);
        }

        public void DeleteComment(int id)
        {
            throw new NotImplementedException();
        }

        public List<Post> FindAll()
        {
            return _items.Values.ToList();
        }

        public Post? FindById(int id)
        {
            return _items[id];
        }

        public int GetCommentId()
        {
            throw new NotImplementedException();
        }

        public void Update(Post item)
        {
            item.PublicationDate = _items[item.Id].PublicationDate;
            _items[item.Id] = item;
        }
    }
}
