using Public.Application.DTOs;
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

    public async Task<List<VisitDto>> GetVisitsAsync()
    {
        var visits = await _visitRepository.GetVisitsAsync();
        return visits.Select(v => new VisitDto
        {
            Id = v.Id,
            PageId = v.PageId,
            VisitedAt = v.VisitedAt
        }).ToList();
    }

    public async Task<List<VisitDto>> GetVisitsByPageAsync(int pageId)
    {
        var visits = await _visitRepository.GetVisitsByPageAsync(pageId);
        return visits.Select(v => new VisitDto
        {
            Id = v.Id,
            PageId = v.PageId,
            VisitedAt = v.VisitedAt
        }).ToList();
    }

    public async Task CreateVisitAsync(CreateVisitDto dto)
    {
        var visit = new Visit
        {
            PageId = dto.PageId,
            VisitedAt = DateTime.UtcNow
        };
        await _visitRepository.CreateVisitAsync(visit);
    }
}
