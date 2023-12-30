using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Laboratorium_3.Models;

public class Comment
{
    [HiddenInput]
    public int CommentId { get; set; }
    
    [Display(Name = "Autor")]
    public required string Author { get; set; }
    
    [Display(Name = "Treść komentarza")]
    public required string Content { get; set; }
    
    [HiddenInput]
    [Display(Name = "Data publikacji")]
    public required DateTime PublicationDate { get; set; }
    public int PostId { get; set; }
}