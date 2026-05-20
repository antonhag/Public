using Microsoft.EntityFrameworkCore;
using Public.Domain.Entities;
using Public.Domain.Interfaces;
using Public.Infrastructure.Data;

namespace Public.Infrastructure.Repositories;

public class ContentBlockRepository : IContentBlockRepository
{
    private readonly MyDbContext _context;

    public ContentBlockRepository(MyDbContext context)
    {
        _context = context; 
    }
    
    public async Task<List<ContentBlock>> GetContentBlocksAsync()
    {
        return await _context.ContentBlocks.ToListAsync();
    }

    public async Task<List<ContentBlock>> GetContentBlockByPageIdAsync(int pageId)
    {
        return await _context.ContentBlocks.Where(x => x.PageId == pageId).ToListAsync();
    }

    public async Task<ContentBlock?> GetContentBlockByIdAsync(int id)
    {
        return await _context.ContentBlocks.FindAsync(id);                                                         
    }

    public async Task CreateContentBlockAsync(ContentBlock contentBlock)
    {
        await _context.ContentBlocks.AddAsync(contentBlock);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateContentBlockAsync(ContentBlock contentBlock)
    {
        _context.ContentBlocks.Update(contentBlock);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteContentBlockAsync(int id)
    {
        var contentBlock = await _context.ContentBlocks.FindAsync(id);
        if (contentBlock == null) return;
        _context.ContentBlocks.Remove(contentBlock);
        await _context.SaveChangesAsync();
    }
}