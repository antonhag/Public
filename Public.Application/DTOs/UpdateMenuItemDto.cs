namespace Public.Application.DTOs;

public class UpdateMenuItemDto
{
    public string MenuTitle { get; set; } = null!;
    public int PageId { get; set; }
    public int Order { get; set; }
}
