using Domain.Objects;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
public class ItemController : ControllerBase
{
    private readonly ItemService _itemService;
    public ItemController(ItemService itemService)
    {
        _itemService = itemService;
    }

    [HttpPost("item")]
    public async Task<IActionResult> Add([FromBody] AddItem item)
    {
        return Ok(await _itemService.Add(item));
    }

    [HttpDelete("item/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _itemService.Delete(id);
        return Ok();
    }

    [HttpPut("item")]
    public async Task<IActionResult> Update([FromBody] UpdateItem item)
    {
        await _itemService.Update(item);
        return Ok();
    }

    [HttpGet("item/{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await _itemService.Get(id));
    }

    [HttpGet("item")]
    public async Task<IActionResult> Get()
    {
        return Ok(await _itemService.Get());
    }

    //[HttpPut("item/{itemId}/assign-shop")]
    //public async Task<IActionResult> AssignShop(int itemId, int toShop)
    //{   
    //    await _itemService.AssignShop(id, toShop);
    //    return NoContent();
    //}

    [HttpPost("buy/id")]
    public async Task<IActionResult> Buy([FromBody] BuyItem item)
    {
        return Ok(await _itemService.Buy(item));
    }
}
