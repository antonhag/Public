namespace Public.Application.DTOs;

public class UpdatePageDto
{
    public string Title { get; set; } = null!;
    public bool IsPublished { get; set; }
    public bool IsHomepage { get; set; }
}
