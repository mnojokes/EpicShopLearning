using Domain.Objects;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
public class ShopController : ControllerBase
{
    private readonly ItemService _itemService;
    public ShopController(ItemService itemService)
    {
        _itemService = itemService;
    }

    [HttpPost("item")]
    public async Task<IActionResult> Add([FromBody] AddItem item)
    {
        return Ok(await _itemService.Add(item));
    }

    [HttpDelete("item")]
    public async Task<IActionResult> Delete([FromBody] ItemId item)
    {
        await _itemService.Delete(item.Id);
        return NoContent();
    }

    [HttpPut("item/id")]
    public async Task<IActionResult> Update([FromBody] UpdateItem item)
    {
        await _itemService.Update(item);
        return NoContent();
    }

    [HttpGet("item/id")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await _itemService.Get(id));
    }

    [HttpGet("item")]
    public async Task<IActionResult> Get()
    {
        return Ok(await _itemService.Get());
    }

    [HttpPost("buy/id")]
    public async Task<IActionResult> Buy([FromBody] BuyItem item)
    {
        return Ok(await _itemService.Buy(item));
    }
}
