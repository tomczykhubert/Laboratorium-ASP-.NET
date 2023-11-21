using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Laboratorium_3.Models
{
    public class Post
    {
        [HiddenInput]
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Treść posta")]
        [MaxLength(length: 300, ErrorMessage = "Zbyt długa treść posta!")]
        public required string Content { get; set; }
        
        [Required]
        [Display(Name = "Autor")]
        [MaxLength(length: 30, ErrorMessage = "Zbyt długa nazwa użytkownika!")]
        public required string Author { get; set; }

        [HiddenInput]
        [Display(Name = "Data publikacji")]
        public DateTime PublicationDate { get; set; }

        [MaxLength(length: 15, ErrorMessage = "Za długa nazwa tagu")]
        [Display(Name = "Tagi")]
        public string? Tags { get; set; }
        [Display(Name = "Komentarze")]
        public List<string>? Comments { get; set; }
        public Post()
        {
            Comments = new List<string>();
        }
    }
}
