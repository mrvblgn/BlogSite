using BlogSite.Models.Dtos.Users.Requests;
using BlogSite.Service.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace blogSite.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(IUserService _userService) : ControllerBase
{
    
    
    [HttpGet("email")]
    public async Task<IActionResult> GetByEmail([FromQuery]string email)
    {
        var result = await _userService.GetByEmailAsycn(email);
        return Ok(result);
    }
}







