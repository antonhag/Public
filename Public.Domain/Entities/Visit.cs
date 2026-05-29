namespace Public.Domain.Entities;

public class Visit
{
    public int Id { get; set; }
    public int PageId { get; set; }
    public DateTime VisitedAt { get; set; }
    public Page Page { get; set; } = null!;
}