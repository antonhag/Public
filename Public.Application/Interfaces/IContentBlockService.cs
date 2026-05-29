using Public.Application.DTOs;

namespace Public.Application.Interfaces;

public interface IContentBlockService
{
    Task<List<ContentBlockDto>> GetContentBlocksAsync();
    Task<List<ContentBlockDto>> GetContentBlocksByPageIdAsync(int pageId);
    Task<ContentBlockDto> GetContentBlockByIdAsync(int id);
    Task CreateContentBlockAsync(CreateContentBlockDto dto);
    Task UpdateContentBlockAsync(int id, UpdateContentBlockDto dto);
    Task DeleteContentBlockAsync(int id);
}
