using System.ComponentModel.DataAnnotations;

namespace Public.UI.Models;

public class CreatePageModel
{
    [Required (ErrorMessage = "Titel krävs!")]
    public string Title { get; set; } = null!;
    public bool IsPublished { get; set; }
}