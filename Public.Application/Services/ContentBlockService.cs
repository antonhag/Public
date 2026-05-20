using Public.Application.Interfaces;
using Public.Domain.Entities;
using Public.Domain.Interfaces;

namespace Public.Application.Services;

public class ContentBlockService : IContentBlockService
{
    private readonly IContentBlockRepository _contentBlockRepository;
    private readonly IPageRepository _pageRepository;

    public ContentBlockService(IContentBlockRepository contentBlockRepository, IPageRepository pageRepository)
    {
        _contentBlockRepository = contentBlockRepository;
        _pageRepository = pageRepository;
    }
    
    public async Task<List<ContentBlock>> GetContentBlocksAsync()
    {
        return await _contentBlockRepository.GetContentBlocksAsync();
    }

    public async Task<List<ContentBlock>> GetContentBlockByPageIdAsync(int pageId)
    {
        return await _contentBlockRepository.GetContentBlockByPageIdAsync(pageId);
    }

    public async Task<ContentBlock> GetContentBlockByIdAsync(int id)
    {
        var contentBlock = await _contentBlockRepository.GetContentBlockByIdAsync(id);
        if (contentBlock == null)
        {
            throw new Exception("Content block not found"); 
        }
        return contentBlock;                                                          
    }

    public async Task CreateContentBlockAsync(ContentBlock contentBlock)
    {
        var page = await _pageRepository.GetPageByIdAsync(contentBlock.PageId);
        if (page == null)
        {
            throw new Exception("Page not found"); 
        }
        await _contentBlockRepository.CreateContentBlockAsync(contentBlock);
    }

    public async Task UpdateContentBlockAsync(ContentBlock contentBlock)
    {
        var contentBlockDb = await _contentBlockRepository.GetContentBlockByIdAsync(contentBlock.Id);
        if (contentBlockDb == null)
        {
            throw new Exception("Content block not found"); 
        }
        await _contentBlockRepository.UpdateContentBlockAsync(contentBlock);
    }

    public async Task DeleteContentBlockAsync(int id)
    {
        var contentBlockDb = await _contentBlockRepository.GetContentBlockByIdAsync(id);
        if (contentBlockDb == null)
        {
            throw new Exception("Content block not found"); 
        }
        await _contentBlockRepository.DeleteContentBlockAsync(id);
    }
}