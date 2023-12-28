using Domain.Objects;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost("user")]
    public async Task<IActionResult> Create([FromBody] CreateUser user)
    {
        return Ok(await _userService.Add(user));
    }

    [HttpGet("user")]
    public async Task<IActionResult> Get()
    {
        return Ok(await _userService.Get());
    }

    [HttpGet("user/id")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await _userService.Get(id));
    }
}
