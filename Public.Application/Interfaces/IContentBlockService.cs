using Public.Domain.Entities;

namespace Public.Application.Interfaces;

public interface IContentBlockService
{
    Task<List<ContentBlock>> GetContentBlocksAsync();
    Task<List<ContentBlock>> GetContentBlockByPageIdAsync(int pageId);
    Task<ContentBlock> GetContentBlockByIdAsync(int id);                                                      
    Task CreateContentBlockAsync(ContentBlock contentBlock);
    Task UpdateContentBlockAsync(ContentBlock contentBlock);
    Task DeleteContentBlockAsync(int id);
}