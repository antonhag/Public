namespace Public.Application.DTOs;

public class CreateMenuItemDto
{
    public string MenuTitle { get; set; } = null!;
    public int PageId { get; set; }
    public int Order { get; set; }
}
