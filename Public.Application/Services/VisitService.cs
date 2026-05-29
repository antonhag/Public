using Public.Application.Interfaces;
using Public.Domain.Entities;
using Public.Domain.Interfaces;

namespace Public.Application.Services;

public class VisitService : IVisitService
{
    private readonly IVisitRepository _visitRepository;

    public VisitService(IVisitRepository visitRepository)
    {
        _visitRepository = visitRepository;
    }
    
    public async Task<List<Visit>> GetVisitsAsync()
    {
        return await _visitRepository.GetVisitsAsync();
    }

    public async Task<List<Visit>> GetVisitsByPageAsync(int pageId)
    {
        return await _visitRepository.GetVisitsByPageAsync(pageId);                                                         
    }

    public async Task CreateVisitAsync(Visit visit)
    {
        await _visitRepository.CreateVisitAsync(visit);                                                         
    }
}