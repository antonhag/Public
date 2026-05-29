using Public.Application.DTOs;

namespace Public.Application.Interfaces;

public interface IVisitService
{
    Task<List<VisitDto>> GetVisitsAsync();
    Task<List<VisitDto>> GetVisitsByPageAsync(int pageId);
    Task CreateVisitAsync(CreateVisitDto dto);
}
