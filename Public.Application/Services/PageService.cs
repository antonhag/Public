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
            IsHomepage = p.IsHomepage,
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
            IsHomepage = page.IsHomepage,
            CreatedAt = page.CreatedAt
        };
    }

    public async Task<PageDto?> GetPageByUrlAsync(string url)
    {
        var page = await _pageRepository.GetPageByUrlAsync(url);

        // Returnera 404 både för opublicerade sidor och sidor som ej finns
        if (page == null || !page.IsPublished)
            return null;

        return new PageDto
        {
            Id = page.Id,
            Title = page.Title,
            Url = page.Url,
            IsPublished = page.IsPublished,
            IsHomepage = page.IsHomepage,
            CreatedAt = page.CreatedAt
        };
    }

    public async Task CreatePageAsync(CreatePageDto dto)
    {
        // Säkerställ att bara EN sida är homepage åt gången
        if (dto.IsHomepage)
        {
            await ClearAllHomepagesAsync();
        }

        var page = new Page
        {
            Title = dto.Title,
            Url = dto.Title.ToLower().Replace(" ", "-").Replace("å", "a").Replace("ä", "a").Replace("ö", "o"),
            IsPublished = dto.IsPublished,
            IsHomepage = dto.IsHomepage,
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

        // Säkerställ att bara EN sida är homepage åt gången
        if (dto.IsHomepage && !page.IsHomepage)
        {
            await ClearAllHomepagesAsync();
        }

        page.Title = dto.Title;
        page.Url = dto.Title.ToLower().Replace(" ", "-").Replace("å", "a").Replace("ä", "a").Replace("ö", "o");
        page.IsPublished = dto.IsPublished;
        page.IsHomepage = dto.IsHomepage;
        await _pageRepository.UpdatePageAsync(page);
    }

    // Nollställer IsHomepage på alla sidor så bara en kan vara hemsida åt gången
    private async Task ClearAllHomepagesAsync()
    {
        var all = await _pageRepository.GetPagesAsync();
        foreach (var p in all.Where(p => p.IsHomepage))
        {
            p.IsHomepage = false;
            await _pageRepository.UpdatePageAsync(p);
        }
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
