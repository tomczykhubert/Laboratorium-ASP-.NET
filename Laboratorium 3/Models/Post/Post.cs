using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Laboratorium_3.Models
{
    public enum Tags
    {
        [Display(Name="Polityka")]
        Politics,
        [Display(Name = "Sport")]
        Sport,
        [Display(Name = "Nauka")]
        Science,
        [Display(Name = "Motoryzacja")]
        Automotive,
        [Display(Name = "Gry")]
        Games
    }
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
        [Required]
        [Display(Name = "Data publikacji")]
        public required DateTime PublicationDate { get; set; }
        
        [Required]
        [Display(Name = "Tagi")]
        public required Tags Tags { get; set; }
        
        [Display(Name = "Komentarze")]
        public List<Comment>? Comments { get; set; }
    }
}
