namespace Public.Application.DTOs;

public class CreateContentBlockDto
{
    public string? Title { get; set; }
    public string? Text { get; set; }
    public string? Image { get; set; }
    public string? Link { get; set; }
    public int PageId { get; set; }
    public string Section { get; set; } = "main";
    public int Order { get; set; }
    public string CssStyle { get; set; } = null!;
}
