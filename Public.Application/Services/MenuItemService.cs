using Public.Application.DTOs;
using Public.Application.Interfaces;
using Public.Domain.Entities;
using Public.Domain.Interfaces;

namespace Public.Application.Services;

public class MenuItemService : IMenuItemService
{
    private readonly IMenuItemRepository _menuItemRepository;
    private readonly IPageRepository _pageRepository;

    public MenuItemService(IMenuItemRepository menuItemRepository, IPageRepository pageRepository)
    {
        _menuItemRepository = menuItemRepository;
        _pageRepository = pageRepository;
    }

    public async Task<List<MenuItemDto>> GetMenuItemsAsync()
    {
        var items = await _menuItemRepository.GetMenuItemsAsync();
        var pages = await _pageRepository.GetPagesAsync();
        
        // sorterar efter Order och behåller bara menyalternativ där sidan är publicerad
        return items.OrderBy(m => m.Order).Where(m => pages.FirstOrDefault(p => p.Id == m.PageId)?.IsPublished == true).Select(m => new MenuItemDto
        {
            Id = m.Id,
            MenuTitle = m.MenuTitle,
            PageId = m.PageId,
            Order = m.Order,
            Url = pages.FirstOrDefault(p => p.Id == m.PageId)?.Url
        }).ToList();
    }

    public async Task<MenuItemDto> GetMenuItemByIdAsync(int id)
    {
        var item = await _menuItemRepository.GetMenuItemByIdAsync(id);
        if (item == null)
        {
            throw new Exception("Menu item not found");
        }
        var page = await _pageRepository.GetPageByIdAsync(item.PageId);
        return new MenuItemDto
        {
            Id = item.Id,
            MenuTitle = item.MenuTitle,
            PageId = item.PageId,
            Order = item.Order,
            Url = page?.Url
        };
    }

    public async Task CreateMenuItemAsync(CreateMenuItemDto dto)
    {
        var page = await _pageRepository.GetPageByIdAsync(dto.PageId);
        if (page == null)
        {
            throw new Exception("Page not found");
        }
        var item = new MenuItem
        {
            MenuTitle = dto.MenuTitle,
            PageId = dto.PageId,
            Order = dto.Order
        };
        await _menuItemRepository.CreateMenuItemAsync(item);
    }

    public async Task UpdateMenuItemAsync(int id, UpdateMenuItemDto dto)
    {
        var item = await _menuItemRepository.GetMenuItemByIdAsync(id);
        if (item == null)
        {
            throw new Exception("Menu item not found");
        }
        item.MenuTitle = dto.MenuTitle;
        item.PageId = dto.PageId;
        item.Order = dto.Order;
        await _menuItemRepository.UpdateMenuItemAsync(item);
    }

    public async Task DeleteMenuItemAsync(int id)
    {
        var item = await _menuItemRepository.GetMenuItemByIdAsync(id);
        if (item == null)
        {
            throw new Exception("Menu item not found");
        }
        await _menuItemRepository.DeleteMenuItemAsync(id);
    }
}
