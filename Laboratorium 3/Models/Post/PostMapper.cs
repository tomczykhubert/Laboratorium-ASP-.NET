using Data.Migrations;

namespace Laboratorium_3.Models
{
    public class PostMapper
    {
        public static Post FromEntity(PostEntity entity)
        {
            return new Post()
            {
                Id = entity.PostId,
                Author = entity.Author,
                Content = entity.Content,
                TagId = entity.TagId,
                PublicationDate = entity.PublicationDate,
                Tag = entity.Tag,
            };
        }

        public static PostEntity ToEntity(Post model)
        {
            return new PostEntity()
            {
                PostId = model.Id,
                Author = model.Author,
                Content = model.Content,
                TagId = model.TagId,
                PublicationDate = model.PublicationDate,
                Tag = model.Tag,
            };
        }
    }
}
