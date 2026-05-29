using System.ComponentModel.DataAnnotations;

namespace Public.Domain.Entities;

public class Page
{
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Title { get; set; }

    [Required]
    [MaxLength(300)]
    public string Url { get; set; }
    public bool IsPublished { get; set; }
    public DateTime CreatedAt { get; set; }

    public List<ContentBlock> ContentBlocks { get; set; } = new List<ContentBlock>();
    public List<Visit> Visits { get; set; } = new List<Visit>();
}