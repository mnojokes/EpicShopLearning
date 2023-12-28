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

    [HttpDelete("shop")]
    public async Task<IActionResult> Delete([FromBody] ShopId id)
    {
        await _shopService.Delete(id.Id);
        return NoContent();
    }

    [HttpPut("shop/id")]
    public async Task<IActionResult> Update([FromBody] UpdateShop shop)
    {
        await _shopService.Update(shop);
        return NoContent();
    }

    [HttpGet("shop/id")]
    public async Task<IActionResult> Get([FromBody] ShopId id)
    {
        return Ok(await _shopService.Get(id.Id));
    }

    [HttpGet("shop")]
    public async Task<IActionResult> Get()
    {
        return Ok(await _shopService.Get());
    }
}
