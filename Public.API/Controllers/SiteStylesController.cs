using Microsoft.AspNetCore.Mvc;
using Public.Application.DTOs;
using Public.Application.Interfaces;

namespace Public.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SiteStylesController : ControllerBase
{
    private readonly ISiteStyleService _siteStyleService;

    public SiteStylesController(ISiteStyleService siteStyleService)
    {
        _siteStyleService = siteStyleService;
    }

    [HttpGet]
    public async Task<List<SiteStyleDto>> Get()
    {
        return await _siteStyleService.GetSiteStylesAsync();
    }

    [HttpGet("active")]
    public async Task<SiteStyleDto?> GetActive()
    {
        return await _siteStyleService.GetActiveSiteStyleAsync();
    }

    [HttpGet("{id}")]
    public async Task<SiteStyleDto> Get(int id)
    {
        return await _siteStyleService.GetSiteStyleByIdAsync(id);
    }

    [HttpPost]
    public async Task Post(CreateSiteStyleDto dto)
    {
        await _siteStyleService.CreateSiteStyleAsync(dto);
    }

    [HttpPut("{id}")]
    public async Task Update(int id, UpdateSiteStyleDto dto)
    {
        await _siteStyleService.UpdateSiteStyleAsync(id, dto);
    }

    [HttpPost("{id}/activate")]
    public async Task Activate(int id)
    {
        await _siteStyleService.SetActiveSiteStyleAsync(id);
    }

    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        await _siteStyleService.DeleteSiteStyleAsync(id);
    }
}
