using Public.Application.DTOs;

namespace Public.Application.Interfaces;

public interface ISiteStyleService
{
    Task<List<SiteStyleDto>> GetSiteStylesAsync();
    Task<SiteStyleDto> GetSiteStyleByIdAsync(int id);
    Task<SiteStyleDto?> GetActiveSiteStyleAsync();
    Task CreateSiteStyleAsync(CreateSiteStyleDto dto);
    Task UpdateSiteStyleAsync(int id, UpdateSiteStyleDto dto);
    Task DeleteSiteStyleAsync(int id);
    Task SetActiveSiteStyleAsync(int id);
    Task DeactivateAllSiteStylesAsync();
}
