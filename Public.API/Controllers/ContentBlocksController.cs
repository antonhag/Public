using Microsoft.AspNetCore.Mvc;
using Public.Application.DTOs;
using Public.Application.Interfaces;

namespace Public.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContentBlocksController : ControllerBase
{
    private readonly IContentBlockService _contentBlockService;

    public ContentBlocksController(IContentBlockService contentBlockService)
    {
        _contentBlockService = contentBlockService;
    }

    [HttpGet]
    public async Task<List<ContentBlockDto>> Get()
    {
        return await _contentBlockService.GetContentBlocksAsync();
    }

    [HttpGet("{id}")]
    public async Task<ContentBlockDto> Get(int id)
    {
        return await _contentBlockService.GetContentBlockByIdAsync(id);
    }

    [HttpGet("page/{pageId}")]
    public async Task<List<ContentBlockDto>> GetByPage(int pageId)
    {
        return await _contentBlockService.GetContentBlocksByPageIdAsync(pageId);
    }

    [HttpPost]
    public async Task Post(CreateContentBlockDto dto)
    {
        await _contentBlockService.CreateContentBlockAsync(dto);
    }

    [HttpPut("{id}")]
    public async Task Update(int id, UpdateContentBlockDto dto)
    {
        await _contentBlockService.UpdateContentBlockAsync(id, dto);
    }

    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        await _contentBlockService.DeleteContentBlockAsync(id);
    }
}
