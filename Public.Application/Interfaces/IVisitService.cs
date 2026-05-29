using Public.Domain.Entities;

namespace Public.Application.Interfaces;

public interface IVisitService
{
    Task<List<Visit>> GetVisitsAsync();
    Task<List<Visit>> GetVisitsByPageAsync(int pageId);
    Task CreateVisitAsync(Visit visit);
}