using Public.Domain.Entities;

namespace Public.Domain.Interfaces;

public interface IVisitRepository
{
    Task<List<Visit>> GetVisitsAsync();
    Task<List<Visit>> GetVisitsByPageAsync(int pageId);
    Task CreateVisitAsync(Visit visit);
}