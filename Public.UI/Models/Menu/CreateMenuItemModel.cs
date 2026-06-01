namespace Public.UI.Models;

public class CreateMenuItemModel
{
    public string MenuTitle { get; set; } = null!;
    public int PageId { get; set; }
    public int Order { get; set; }
}