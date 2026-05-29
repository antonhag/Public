using Public.Application.DTOs;

namespace Public.Application.Interfaces;

public interface IMenuItemService
{
    Task<List<MenuItemDto>> GetMenuItemsAsync();
    Task<MenuItemDto> GetMenuItemByIdAsync(int id);
    Task CreateMenuItemAsync(CreateMenuItemDto dto);
    Task UpdateMenuItemAsync(int id, UpdateMenuItemDto dto);
    Task DeleteMenuItemAsync(int id);
}
