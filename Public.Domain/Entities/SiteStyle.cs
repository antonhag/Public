using System.ComponentModel.DataAnnotations;

namespace Public.Domain.Entities;

public class SiteStyle
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = "Default"; 

    public bool IsActive { get; set; }
  
    // Rubrik
    public string HeadingColor { get; set; } = "#000000";
    public string HeadingFont { get; set; } = "Arial";
    public int HeadingSize { get; set; } = 32;
  
    // Text
    public string TextColor { get; set; } = "#333333";
    public string TextFont { get; set; } = "Arial";
    public int TextSize { get; set; } = 16;
  
    // Bild
    public int ImageBorderRadius { get; set; } = 0;
    public string ImageBorderColor { get; set; } = "#cccccc";
  
    // Länk
    public string LinkColor { get; set; } = "#0066cc";
    public bool LinkUnderline { get; set; } = true;
}