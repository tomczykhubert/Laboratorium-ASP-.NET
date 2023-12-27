using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public class CommentEntity
{
    [Key] public int CommentId { get; set; }

    [Required] [MaxLength(30)] public string Author { get; set; }

    [MaxLength(300)] [Required] public string Content { get; set; }

    [Required] public DateTime PublicationDate { get; set; }

    [Required] public int PostId { get; set; }

    [Required] public PostEntity Post { get; set; }
}
