using System.ComponentModel.DataAnnotations;

namespace Public.Domain.Entities;

public class MenuItem
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string MenuTitle { get; set; }
    public int PageId { get; set; }
    public int Order { get; set; }
    
    public Page Page { get; set; }
}