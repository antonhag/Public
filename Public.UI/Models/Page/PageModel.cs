namespace Public.UI.Models;

public class PageModel
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Url { get; set; } = null!;
    public bool IsPublished { get; set; }
    public bool IsHomepage { get; set; }
    public DateTime CreatedAt { get; set; }
}
