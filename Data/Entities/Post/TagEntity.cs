using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Post
{
    public class TagEntity
    {
        [Key]
        public int TagId { get; set; }
        [Required]
        public string TagName { get; set; }
        public ISet<PostEntity>? Posts { get; set; }
    }
}
