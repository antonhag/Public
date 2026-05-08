using Public.Domain.Entities;

namespace Public.Application.Interfaces;

public interface IMenuItemService
{
    Task<List<MenuItem>> GetMenuItemsAsync();
    Task<MenuItem> GetMenuItemByIdAsync(int id);
    Task CreateMenuItemAsync(MenuItem menuItem);
    Task UpdateMenuItemAsync(MenuItem menuItem);
    Task DeleteMenuItemAsync(int id);
}