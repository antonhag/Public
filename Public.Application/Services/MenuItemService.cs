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
    
    public async Task<List<MenuItem>> GetMenuItemsAsync()
    {
        return await _menuItemRepository.GetMenuItemsAsync();
    }

    public async Task<MenuItem> GetMenuItemByIdAsync(int id)
    {
        var menuItem = await _menuItemRepository.GetMenuItemByIdAsync(id);
        if (menuItem == null)
        {
            throw new Exception("Menu item not found"); 
        }
        return menuItem;                                                         
    }

    public async Task CreateMenuItemAsync(MenuItem menuItem)
    {
        var page = await _pageRepository.GetPageByIdAsync(menuItem.PageId);
        if (page == null)
        {
            throw new Exception("Page not found"); 
        }
        await _menuItemRepository.CreateMenuItemAsync(menuItem);
    }

    public async Task UpdateMenuItemAsync(MenuItem menuItem)
    {
        var menuItemDb = await _menuItemRepository.GetMenuItemByIdAsync(menuItem.Id);
        if (menuItemDb == null)
        {
            throw new Exception("Menu item not found"); 
        }
        await _menuItemRepository.UpdateMenuItemAsync(menuItem);
    }

    public async Task DeleteMenuItemAsync(int id)
    {
        await _menuItemRepository.DeleteMenuItemAsync(id);
    }
}