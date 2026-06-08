namespace Public.UI.Models;

public class UpdatePageModel
{
    public string Title { get; set; } = null!;
    public bool IsPublished { get; set; }
    public bool IsHomepage { get; set; }
}