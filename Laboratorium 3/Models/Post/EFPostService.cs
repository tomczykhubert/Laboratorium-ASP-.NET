using Data;
using Data.Entities.Post;
using Microsoft.EntityFrameworkCore;

namespace Laboratorium_3.Models
{
    public class EFPostService : IPostService
    {
        private readonly AppDbContext _context;

        public EFPostService(AppDbContext context)
        {
            _context = context;
        }

        public int Add(Post model)
        {
            var e = _context.Posts.Add(PostMapper.ToEntity(model));
            _context.SaveChanges();
            return e.Entity.PostId;
        }

        public void Delete(int id)
        {
            var find = _context.Posts.Find(id);
            if (find != null)
            {
                _context.Posts.Remove(find);
                _context.SaveChanges();
            }
        }

        public List<Post> FindAll()
        {
            return _context
               .Posts
               .Include(p => p.Tag)
               .Select(e => PostMapper.FromEntity(e))
               .ToList();
        }

        public Post? FindById(int id)
        {
            var find = _context.Posts.Include(p => p.Tag).Single(p => p.PostId == id);
            return find is null ? null : PostMapper.FromEntity(find);
        }

        public List<Post> FindByTag(int tagId)
        {
            return _context.Posts.Where(o => o.TagId == tagId).Select(o => PostMapper.FromEntity(o)).ToList();
        }

        public void Update(Post model)
        {
            var entity = PostMapper.ToEntity(model);
            _context.Update(entity);
            _context.SaveChanges();
        }

        public void AddComment(Comment model)
        {
            var e = _context.Comments.Add(CommentMapper.ToEntity(model));
            _context.SaveChanges();
        }

        public void DeleteComment(int id)
        {
            var find = _context.Comments.Find(id);
            if (find != null)
            {
                _context.Comments.Remove(find);
                _context.SaveChanges();
            }
        }
        public int GetCommentId()
        {
            return _context.Comments.Count() + 1;
        }
    }
}
