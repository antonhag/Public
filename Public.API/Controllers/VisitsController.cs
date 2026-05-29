using Microsoft.AspNetCore.Mvc;
using Public.Application.DTOs;
using Public.Application.Interfaces;

namespace Public.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VisitsController : ControllerBase
{
    private readonly IVisitService _visitService;

    public VisitsController(IVisitService visitService)
    {
        _visitService = visitService;
    }

    [HttpGet]
    public async Task<List<VisitDto>> Get()
    {
        return await _visitService.GetVisitsAsync();
    }

    [HttpGet("page/{pageId}")]
    public async Task<List<VisitDto>> GetByPage(int pageId)
    {
        return await _visitService.GetVisitsByPageAsync(pageId);
    }

    [HttpPost]
    public async Task Post(CreateVisitDto dto)
    {
        await _visitService.CreateVisitAsync(dto);
    }
}
