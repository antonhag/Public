using Public.Domain.Entities;

namespace Public.Domain.Interfaces;

public interface IPageRepository
{
    Task<List<Page>> GetPagesAsync();
    Task<Page?> GetPageByIdAsync(int id);
    Task CreatePageAsync(Page page);
    Task UpdatePageAsync(Page page);
    Task DeletePageAsync(int id);
}