using Microsoft.AspNetCore.Mvc;
using UserTestingApp.BLL.Interfaces;
using UserTestingApp.Common.DTOs.Auth;

namespace UserTestingApp.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("sign-in")]
    public async Task<ActionResult<TokenDto>> SignIn([FromBody] LoginDto login)
    {
        var token = await _authService.SignInAsync(login);

        return Ok(token);
    }
}
