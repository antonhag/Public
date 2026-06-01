namespace Public.UI.Models;

public class UpdateMenuItemModel
{
    public string MenuTitle { get; set; } = null!;
    public int PageId { get; set; }
    public int Order { get; set; }
}