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

        public void Delete(int id)
        {
            _items.Remove(id);
        }

        public List<Post> FindAll()
        {
            return _items.Values.ToList();
        }

        public Post? FindById(int id)
        {
            return _items[id];
        }

        public void Update(Post item)
        {
            item.PublicationDate = _items[item.Id].PublicationDate;
            item.Comments = _items[item.Id].Comments;
            _items[item.Id] = item;
        }
        public void AddComment(Post item, string comment)
        {
            _items[item.Id].Comments.Add(comment);
        }
    }
}
