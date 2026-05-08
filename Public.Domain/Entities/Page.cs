namespace Public.Domain.Entities;

public class Page
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Url { get; set; }
    public bool IsPublished { get; set; }
    public DateTime CreatedAt { get; set; }

    public List<ContentBlock> ContentBlocks { get; set; } = new List<ContentBlock>();
}