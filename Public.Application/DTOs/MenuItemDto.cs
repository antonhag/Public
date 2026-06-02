namespace Public.Application.DTOs;

public class MenuItemDto
{
    public int Id { get; set; }
    public string MenuTitle { get; set; } = null!;
    public int PageId { get; set; }
    public int Order { get; set; }
    public string? Url { get; set; }
}
