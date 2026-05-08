using Public.Domain.Entities;

namespace Public.Domain.Interfaces;

public interface IMenuItemRepository
{
    Task<List<MenuItem>> GetMenuItemsAsync();
    Task<MenuItem?> GetMenuItemByIdAsync(int id);
    Task CreateMenuItemAsync(MenuItem menuItem);
    Task UpdateMenuItemAsync(MenuItem menuItem);
    Task DeleteMenuItemAsync(int id);
}