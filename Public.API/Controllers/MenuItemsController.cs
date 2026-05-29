using Microsoft.AspNetCore.Mvc;
using Public.Application.DTOs;
using Public.Application.Interfaces;

namespace Public.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MenuItemsController : ControllerBase
{
    private readonly IMenuItemService _menuItemService;

    public MenuItemsController(IMenuItemService menuItemService)
    {
        _menuItemService = menuItemService;
    }

    [HttpGet]
    public async Task<List<MenuItemDto>> Get()
    {
        return await _menuItemService.GetMenuItemsAsync();
    }

    [HttpGet("{id}")]
    public async Task<MenuItemDto> Get(int id)
    {
        return await _menuItemService.GetMenuItemByIdAsync(id);
    }

    [HttpPost]
    public async Task Post(CreateMenuItemDto dto)
    {
        await _menuItemService.CreateMenuItemAsync(dto);
    }

    [HttpPut("{id}")]
    public async Task Update(int id, UpdateMenuItemDto dto)
    {
        await _menuItemService.UpdateMenuItemAsync(id, dto);
    }

    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        await _menuItemService.DeleteMenuItemAsync(id);
    }
}
