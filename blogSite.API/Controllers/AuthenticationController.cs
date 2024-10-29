using BlogSite.Models.Dtos.Users.Requests;
using BlogSite.Service.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace blogSite.API.Controllers;

public class AuthenticationController(IAuthenticationService _authenticationService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody]LoginRequestDto dto)
    {
        var result = await _authenticationService.LoginAsync(dto);
        return Ok(result);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDto dto)
    {
        var result = await _authenticationService.RegisterAsync(dto);
        return Ok(result);
    }
}