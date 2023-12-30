using Data.Migrations;

namespace Laboratorium_3.Models
{
    public class CommentMapper
    {
        public static Comment FromEntity(CommentEntity entity)
        {
            return new Comment()
            {
                CommentId = entity.CommentId,
                Author = entity.Author,
                Content = entity.Content,
                PublicationDate = entity.PublicationDate,
                PostId = entity.PostId,
            };
        }

        public static CommentEntity ToEntity(Comment model)
        {
            return new CommentEntity()
            {
                CommentId = model.CommentId,
                Author = model.Author,
                Content = model.Content,
                PublicationDate = model.PublicationDate,
                PostId = model.PostId,
            };
        }
    }
}
