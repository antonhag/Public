using Microsoft.EntityFrameworkCore;
using Public.Domain.Entities;
using Public.Domain.Interfaces;
using Public.Infrastructure.Data;

namespace Public.Infrastructure.Repositories;

public class VisitRepository : IVisitRepository
{
    private readonly MyDbContext _context;

    public VisitRepository(MyDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Visit>> GetVisitsAsync()
    {
        return await _context.Visits.ToListAsync();
    }

    public async Task<List<Visit>> GetVisitsByPageAsync(int pageId)
    {
        return await _context.Visits.Where(x => x.PageId == pageId).ToListAsync();                                                         
    }

    public async Task CreateVisitAsync(Visit visit)
    {
        await _context.Visits.AddAsync(visit);
        await _context.SaveChangesAsync();
    }
}