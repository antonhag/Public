namespace Public.Application.DTOs;

public class CreatePageDto
{
    public string Title { get; set; } = null!;
    public string Url { get; set; } = null!;
    public bool IsPublished { get; set; }
}
