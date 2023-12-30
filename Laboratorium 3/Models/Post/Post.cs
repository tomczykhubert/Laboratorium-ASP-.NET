using Data.Entities.Post;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Laboratorium_3.Models
{
    public class Post
    {
        [HiddenInput]
        public int Id { get; set; }

        [Display(Name = "Treść posta")]
        [MaxLength(length: 300, ErrorMessage = "Zbyt długa treść posta!")]
        public string Content { get; set; }

        [Display(Name = "Autor")]
        [MaxLength(length: 30, ErrorMessage = "Zbyt długa nazwa użytkownika!")]
        public string Author { get; set; }

        [HiddenInput]
        [Display(Name = "Data publikacji")]
        public DateTime PublicationDate { get; set; }

        public int TagId { get; set; }

        public TagEntity? Tag { get; set; }
    }
}