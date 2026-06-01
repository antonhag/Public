using System.ComponentModel.DataAnnotations;

namespace Public.UI.Models;

public class CreateContentBlockModel
{
    public string? Title { get; set; }
    public string? Text { get; set; }
    public string? Image { get; set; }
    public string? Link { get; set; }

    [Required(ErrorMessage = "Du måste välja en sida")]
    [Range(1, int.MaxValue, ErrorMessage = "Du måste välja en sida")]
    public int PageId { get; set; }
    public string Section { get; set; } = "main";
    public int Order { get; set; }
    public string CssStyle { get; set; } = null!;
}