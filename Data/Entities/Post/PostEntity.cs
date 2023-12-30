using Data.Entities.Post;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PostEntity
{
    [Key]
    public int PostId { get; set; }

    [Required]
    [MaxLength(30)]
    public string Author { get; set; }

    [Required]
    [MaxLength(300)]
    public string Content { get; set; }

    [Required]
    public DateTime PublicationDate { get; set; }

    [Required]
    public int TagId { get; set; }

    [Required]
    public TagEntity? Tag { get; set; }

    public ISet<CommentEntity>? Comments { get; set; }
}