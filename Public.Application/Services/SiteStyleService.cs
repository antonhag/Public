using Public.Application.DTOs;
using Public.Application.Interfaces;
using Public.Domain.Entities;
using Public.Domain.Interfaces;

namespace Public.Application.Services;

public class SiteStyleService : ISiteStyleService
{
    private readonly ISiteStyleRepository _siteStyleRepository;

    public SiteStyleService(ISiteStyleRepository siteStyleRepository)
    {
        _siteStyleRepository = siteStyleRepository;
    }

    public async Task<List<SiteStyleDto>> GetSiteStylesAsync()
    {
        var styles = await _siteStyleRepository.GetSiteStylesAsync();
        return styles.Select(s => new SiteStyleDto
        {
            Id = s.Id,
            Name = s.Name,
            IsActive = s.IsActive,
            HeadingColor = s.HeadingColor,
            HeadingFont = s.HeadingFont,
            HeadingSize = s.HeadingSize,
            TextColor = s.TextColor,
            TextFont = s.TextFont,
            TextSize = s.TextSize,
            ImageBorderRadius = s.ImageBorderRadius,
            ImageBorderColor = s.ImageBorderColor,
            LinkColor = s.LinkColor,
            LinkUnderline = s.LinkUnderline
        }).ToList();
    }

    public async Task<SiteStyleDto> GetSiteStyleByIdAsync(int id)
    {
        var style = await _siteStyleRepository.GetSiteStyleByIdAsync(id);
        if (style == null)
        {
            throw new Exception("Site style not found");
        }
        return new SiteStyleDto
        {
            Id = style.Id,
            Name = style.Name,
            IsActive = style.IsActive,
            HeadingColor = style.HeadingColor,
            HeadingFont = style.HeadingFont,
            HeadingSize = style.HeadingSize,
            TextColor = style.TextColor,
            TextFont = style.TextFont,
            TextSize = style.TextSize,
            ImageBorderRadius = style.ImageBorderRadius,
            ImageBorderColor = style.ImageBorderColor,
            LinkColor = style.LinkColor,
            LinkUnderline = style.LinkUnderline
        };
    }

    public async Task<SiteStyleDto?> GetActiveSiteStyleAsync()
    {
        var style = await _siteStyleRepository.GetActiveSiteStyleAsync();
        if (style == null) return null;
        return new SiteStyleDto
        {
            Id = style.Id,
            Name = style.Name,
            IsActive = style.IsActive,
            HeadingColor = style.HeadingColor,
            HeadingFont = style.HeadingFont,
            HeadingSize = style.HeadingSize,
            TextColor = style.TextColor,
            TextFont = style.TextFont,
            TextSize = style.TextSize,
            ImageBorderRadius = style.ImageBorderRadius,
            ImageBorderColor = style.ImageBorderColor,
            LinkColor = style.LinkColor,
            LinkUnderline = style.LinkUnderline
        };
    }

    public async Task CreateSiteStyleAsync(CreateSiteStyleDto dto)
    {
        var style = new SiteStyle
        {
            Name = dto.Name,
            HeadingColor = dto.HeadingColor,
            HeadingFont = dto.HeadingFont,
            HeadingSize = dto.HeadingSize,
            TextColor = dto.TextColor,
            TextFont = dto.TextFont,
            TextSize = dto.TextSize,
            ImageBorderRadius = dto.ImageBorderRadius,
            ImageBorderColor = dto.ImageBorderColor,
            LinkColor = dto.LinkColor,
            LinkUnderline = dto.LinkUnderline
        };
        await _siteStyleRepository.CreateSiteStyleAsync(style);
    }

    public async Task UpdateSiteStyleAsync(int id, UpdateSiteStyleDto dto)
    {
        var style = await _siteStyleRepository.GetSiteStyleByIdAsync(id);
        if (style == null)
        {
            throw new Exception("Site style not found");
        }
        style.Name = dto.Name;
        style.HeadingColor = dto.HeadingColor;
        style.HeadingFont = dto.HeadingFont;
        style.HeadingSize = dto.HeadingSize;
        style.TextColor = dto.TextColor;
        style.TextFont = dto.TextFont;
        style.TextSize = dto.TextSize;
        style.ImageBorderRadius = dto.ImageBorderRadius;
        style.ImageBorderColor = dto.ImageBorderColor;
        style.LinkColor = dto.LinkColor;
        style.LinkUnderline = dto.LinkUnderline;

        await _siteStyleRepository.UpdateSiteStyleAsync(style);
    }

    public async Task DeleteSiteStyleAsync(int id)
    {
        var style = await _siteStyleRepository.GetSiteStyleByIdAsync(id);
        if (style == null)
        {
            throw new Exception("Site style not found");
        }
        await _siteStyleRepository.DeleteSiteStyleAsync(id);
    }

    public async Task SetActiveSiteStyleAsync(int id)
    {
        var style = await _siteStyleRepository.GetSiteStyleByIdAsync(id);
        if (style == null)
        {
            throw new Exception("Site style not found");
        }
        await _siteStyleRepository.SetActiveSiteStyleAsync(id);
    }

    public async Task DeactivateAllSiteStylesAsync()
    {
        await _siteStyleRepository.DeactivateAllSiteStylesAsync();
    }
}
