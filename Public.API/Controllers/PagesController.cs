using Microsoft.AspNetCore.Mvc;
using Public.Application.DTOs;
using Public.Application.Interfaces;

namespace Public.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PagesController : ControllerBase
{
    private readonly IPageService _pageService;

    public PagesController(IPageService pageService)
    {
        _pageService = pageService;
    }

    [HttpGet]
    public async Task<List<PageDto>> Get()
    {
        return await _pageService.GetPagesAsync();
    }
    
    [HttpGet("{id}")]
    public async Task<PageDto> Get(int id)
    {
        return await _pageService.GetPageByIdAsync(id);
    }

    [HttpPost]
    public async Task Post(CreatePageDto dto)
    {
        await _pageService.CreatePageAsync(dto);
    }

    [HttpPut("{id}")]
    public async Task Update(int id, UpdatePageDto dto)
    {
        await _pageService.UpdatePageAsync(id, dto);
    }
    
    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        await _pageService.DeletePageAsync(id);
    }
    
}