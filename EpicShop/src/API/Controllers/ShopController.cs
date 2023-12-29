using Domain.Objects;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
public class ShopController : ControllerBase
{
    private readonly ShopService _shopService;
    public ShopController(ShopService shopService)
    {
        _shopService = shopService;
    }

    [HttpPost("shop")]
    public async Task<IActionResult> Create([FromBody] CreateShop shop)
    {
        return Ok(await _shopService.Create(shop));
    }

    [HttpDelete("shop/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _shopService.Delete(id);
        return Ok();
    }

    [HttpPut("shop")]
    public async Task<IActionResult> Update([FromBody] UpdateShop shop)
    {
        await _shopService.Update(shop);
        return Ok();
    }

    [HttpGet("shop/{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await _shopService.Get(id));
    }

    [HttpGet("shop")]
    public async Task<IActionResult> Get()
    {
        return Ok(await _shopService.Get());
    }
}
