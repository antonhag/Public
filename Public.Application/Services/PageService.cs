using Public.Application.DTOs;
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

    public async Task<List<PageDto>> GetPagesAsync()
    {
        var pages = await _pageRepository.GetPagesAsync();
        return pages.Select(p => new PageDto
        {
            Id = p.Id,
            Title = p.Title,
            Url = p.Url,
            IsPublished = p.IsPublished,
            CreatedAt = p.CreatedAt
        }).ToList();
    }

    public async Task<PageDto> GetPageByIdAsync(int id)
    {
        var page = await _pageRepository.GetPageByIdAsync(id);
        if (page == null)
        {
            throw new Exception("Page not found");
        }
        return new PageDto
        {
            Id = page.Id,
            Title = page.Title,
            Url = page.Url,
            IsPublished = page.IsPublished,
            CreatedAt = page.CreatedAt
        };
    }

    public async Task CreatePageAsync(CreatePageDto dto)
    {
        var page = new Page
        {
            Title = dto.Title,
            Url = dto.Title.ToLower().Replace(" ", "-").Replace("å", "a").Replace("ä", "a").Replace("ö", "o"), // Tar sidans titel och gör den till en giltig URL.
            IsPublished = dto.IsPublished,
            CreatedAt = DateTime.UtcNow
        };
        await _pageRepository.CreatePageAsync(page);
    }

    public async Task UpdatePageAsync(int id, UpdatePageDto dto)
    {
        var page = await _pageRepository.GetPageByIdAsync(id);
        if (page == null)
        {
            throw new Exception("Page not found");
        }
        page.Title = dto.Title;
        page.Url = dto.Title.ToLower().Replace(" ", "-").Replace("å", "a").Replace("ä", "a").Replace("ö", "o");
        page.IsPublished = dto.IsPublished;
        await _pageRepository.UpdatePageAsync(page);
    }

    public async Task DeletePageAsync(int id)
    {
        var page = await _pageRepository.GetPageByIdAsync(id);
        if (page == null)
        {
            throw new Exception("Page not found");
        }
        await _pageRepository.DeletePageAsync(id);
    }
}
