using System.ComponentModel.DataAnnotations;

namespace Public.UI.Models;

public class UpdateSiteStyleModel
{
    [Required(ErrorMessage = "Namn krävs")]
    public string Name { get; set; } = "Default";

    public string HeadingColor { get; set; } = "#000000";
    public string HeadingFont { get; set; } = "Arial";
    public int HeadingSize { get; set; } = 32;

    public string TextColor { get; set; } = "#333333";
    public string TextFont { get; set; } = "Arial";
    public int TextSize { get; set; } = 16;

    public int ImageBorderRadius { get; set; } = 0;
    public string ImageBorderColor { get; set; } = "#cccccc";

    public string LinkColor { get; set; } = "#0066cc";
    public bool LinkUnderline { get; set; } = true;
}
