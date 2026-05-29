using System.ComponentModel.DataAnnotations;

namespace Public.Domain.Entities;

public class ContentBlock
{
    public int Id { get; set; }

    [MaxLength(200)]
    public string? Title { get; set; }
    public string? Text { get; set; }
    public string? Image { get; set; }
    public string? Link { get; set; }
    public int PageId { get; set; }
    public int Order { get; set; }

    [Required]
    public string CssStyle { get; set; } = null!;

    public Page Page { get; set; } = null!;
}