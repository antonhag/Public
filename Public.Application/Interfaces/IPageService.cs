using Public.Application.DTOs;

namespace Public.Application.Interfaces;

public interface IPageService
{
    Task<List<PageDto>> GetPagesAsync();
    Task<PageDto> GetPageByIdAsync(int id);
    Task<PageDto?> GetPageByUrlAsync(string url);
    Task CreatePageAsync(CreatePageDto dto);
    Task UpdatePageAsync(int id, UpdatePageDto dto);
    Task DeletePageAsync(int id);
}
