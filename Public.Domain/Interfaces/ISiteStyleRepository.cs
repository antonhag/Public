using Public.Domain.Entities;

namespace Public.Domain.Interfaces;

public interface ISiteStyleRepository
{
    Task<List<SiteStyle>> GetSiteStylesAsync();
    Task<SiteStyle?> GetSiteStyleByIdAsync(int id);
    Task<SiteStyle?> GetActiveSiteStyleAsync();
    Task CreateSiteStyleAsync(SiteStyle siteStyle);
    Task UpdateSiteStyleAsync(SiteStyle siteStyle);
    Task DeleteSiteStyleAsync(int id);
    Task SetActiveSiteStyleAsync(int id);
    Task DeactivateAllSiteStylesAsync();
}
