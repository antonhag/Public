using Microsoft.EntityFrameworkCore;
using Public.Domain.Entities;
using Public.Domain.Interfaces;
using Public.Infrastructure.Data;

namespace Public.Infrastructure.Repositories;

public class SiteStyleRepository : ISiteStyleRepository
{
    private readonly MyDbContext _context;

    public SiteStyleRepository(MyDbContext context)
    {
        _context = context;
    }

    public async Task<List<SiteStyle>> GetSiteStylesAsync()
    {
        return await _context.SiteStyles.ToListAsync();
    }

    public async Task<SiteStyle?> GetSiteStyleByIdAsync(int id)
    {
        return await _context.SiteStyles.FindAsync(id);
    }

    public async Task<SiteStyle?> GetActiveSiteStyleAsync()
    {
        return await _context.SiteStyles.FirstOrDefaultAsync(s => s.IsActive);
    }

    public async Task CreateSiteStyleAsync(SiteStyle siteStyle)
    {
        await _context.SiteStyles.AddAsync(siteStyle);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateSiteStyleAsync(SiteStyle siteStyle)
    {
        _context.SiteStyles.Update(siteStyle);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteSiteStyleAsync(int id)
    {
        var siteStyle = await _context.SiteStyles.FindAsync(id);
        if (siteStyle == null) return;
        _context.SiteStyles.Remove(siteStyle);
        await _context.SaveChangesAsync();
    }

    public async Task SetActiveSiteStyleAsync(int id)
    {
        var all = await _context.SiteStyles.ToListAsync();
        foreach (var s in all)
        {
            s.IsActive = s.Id == id;
        }
        await _context.SaveChangesAsync();
    }

    public async Task DeactivateAllSiteStylesAsync()
    {
        var all = await _context.SiteStyles.ToListAsync();
        foreach (var s in all)
        {
            s.IsActive = false;
        }
        await _context.SaveChangesAsync();
    }
}
