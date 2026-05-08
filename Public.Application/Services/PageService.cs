using Public.Application.Interfaces;
using Public.Domain.Entities;
using Public.Domain.Interfaces;

namespace Public.Application.Services;

public class PageService : IPageService
{
    private readonly IPageRepository _pageRepository;

    public PageService(IPageRepository pageRepository)
    {
        _pageRepository = pageRepository;   
    }
    public async Task<List<Page>> GetPagesAsync()
    {
        return await _pageRepository.GetPagesAsync();
    }

    public async Task<Page> GetPageByIdAsync(int id)
    {
        var page = await _pageRepository.GetPageByIdAsync(id);
        if (page == null)
        {
            throw new Exception("Page not found"); 
        }
        return page;                                                         
    }

    public async Task CreatePageAsync(Page page)
    {
        var pageDb = await _pageRepository.GetPageByIdAsync(page.Id);
        if (pageDb != null)
        {
            throw new Exception("Page already exists"); 
        }
        await _pageRepository.CreatePageAsync(page);
    }

    public async Task UpdatePageAsync(Page page)
    {
        var pageDb = await _pageRepository.GetPageByIdAsync(page.Id);
        if (pageDb == null)
        {
            throw new Exception("Page not found"); 
        }
        await _pageRepository.UpdatePageAsync(page);
    }

    public async Task DeletePageAsync(int id)
    {
        await _pageRepository.DeletePageAsync(id);
    }
}