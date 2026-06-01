using Microsoft.EntityFrameworkCore;
using Public.Domain.Entities;
using Public.Domain.Interfaces;
using Public.Infrastructure.Data;

namespace Public.Infrastructure.Repositories;

public class PageRepository : IPageRepository
{
    private readonly MyDbContext _context;

    public PageRepository(MyDbContext context)
    {
        _context = context;  
    }
    
    public async Task<List<Page>> GetPagesAsync()
    {
        return await _context.Pages.ToListAsync();
    }

    public async Task<Page?> GetPageByIdAsync(int id)
    {
        return await _context.Pages.FindAsync(id);
    }

    public async Task<Page?> GetPageByUrlAsync(string url)
    {
        return await _context.Pages.FirstOrDefaultAsync(p => p.Url == url);                                                         
    }

    public async Task CreatePageAsync(Page page)
    {
        await _context.Pages.AddAsync(page);
        await _context.SaveChangesAsync();
    }

    public async Task UpdatePageAsync(Page page)
    {
        _context.Pages.Update(page);
        await _context.SaveChangesAsync();
    }

    public async Task DeletePageAsync(int id)
    {
        var page = await _context.Pages.FindAsync(id);
        if (page == null) return;
        _context.Pages.Remove(page);
        await _context.SaveChangesAsync();
    }
}