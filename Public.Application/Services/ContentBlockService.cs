using Public.Application.DTOs;
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

    public async Task<List<ContentBlockDto>> GetContentBlocksAsync()
    {
        var blocks = await _contentBlockRepository.GetContentBlocksAsync();
        return blocks.Select(b => new ContentBlockDto
        {
            Id = b.Id,
            Title = b.Title,
            Text = b.Text,
            Image = b.Image,
            Link = b.Link,
            PageId = b.PageId,
            Order = b.Order,
            CssStyle = b.CssStyle
        }).ToList();
    }

    public async Task<List<ContentBlockDto>> GetContentBlocksByPageIdAsync(int pageId)
    {
        var blocks = await _contentBlockRepository.GetContentBlockByPageIdAsync(pageId);
        return blocks.Select(b => new ContentBlockDto
        {
            Id = b.Id,
            Title = b.Title,
            Text = b.Text,
            Image = b.Image,
            Link = b.Link,
            PageId = b.PageId,
            Order = b.Order,
            CssStyle = b.CssStyle
        }).ToList();
    }

    public async Task<ContentBlockDto> GetContentBlockByIdAsync(int id)
    {
        var block = await _contentBlockRepository.GetContentBlockByIdAsync(id);
        if (block == null)
        {
            throw new Exception("Content block not found");
        }
        return new ContentBlockDto
        {
            Id = block.Id,
            Title = block.Title,
            Text = block.Text,
            Image = block.Image,
            Link = block.Link,
            PageId = block.PageId,
            Order = block.Order,
            CssStyle = block.CssStyle
        };
    }

    public async Task CreateContentBlockAsync(CreateContentBlockDto dto)
    {
        var page = await _pageRepository.GetPageByIdAsync(dto.PageId);
        if (page == null)
        {
            throw new Exception("Page not found");
        }
        var block = new ContentBlock
        {
            Title = dto.Title,
            Text = dto.Text,
            Image = dto.Image,
            Link = dto.Link,
            PageId = dto.PageId,
            Order = dto.Order,
            CssStyle = dto.CssStyle
        };
        await _contentBlockRepository.CreateContentBlockAsync(block);
    }

    public async Task UpdateContentBlockAsync(int id, UpdateContentBlockDto dto)
    {
        var block = await _contentBlockRepository.GetContentBlockByIdAsync(id);
        if (block == null)
        {
            throw new Exception("Content block not found");
        }
        block.Title = dto.Title;
        block.Text = dto.Text;
        block.Image = dto.Image;
        block.Link = dto.Link;
        block.PageId = dto.PageId;
        block.Order = dto.Order;
        block.CssStyle = dto.CssStyle;
        await _contentBlockRepository.UpdateContentBlockAsync(block);
    }

    public async Task DeleteContentBlockAsync(int id)
    {
        var block = await _contentBlockRepository.GetContentBlockByIdAsync(id);
        if (block == null)
        {
            throw new Exception("Content block not found");
        }
        await _contentBlockRepository.DeleteContentBlockAsync(id);
    }
}
