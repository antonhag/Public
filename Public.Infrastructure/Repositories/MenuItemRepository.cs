using Microsoft.EntityFrameworkCore;
using Public.Domain.Entities;
using Public.Domain.Interfaces;
using Public.Infrastructure.Data;

namespace Public.Infrastructure.Repositories;

public class MenuItemRepository : IMenuItemRepository
{
    private readonly MyDbContext _context;

    public MenuItemRepository(MyDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<MenuItem>> GetMenuItemsAsync()
    {
        return await _context.MenuItems.ToListAsync();
    }

    public async Task<MenuItem?> GetMenuItemByIdAsync(int id)
    {
        return await _context.MenuItems.FindAsync(id);                                                         
    }

    public async Task CreateMenuItemAsync(MenuItem menuItem)
    {
        await _context.MenuItems.AddAsync(menuItem);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateMenuItemAsync(MenuItem menuItem)
    {
        _context.MenuItems.Update(menuItem);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteMenuItemAsync(int id)
    {
        var menuItem = await _context.MenuItems.FindAsync(id);
        if (menuItem == null) return;
        _context.MenuItems.Remove(menuItem);
        await _context.SaveChangesAsync();
    }
}