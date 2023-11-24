using Microsoft.AspNetCore.Mvc;
using UserTestingApp.Common.DTOs.Auth;

namespace UserTestingApp.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{

    [HttpPost("sign-in")]
    public Task<ActionResult<TokenDto>> SignIn([FromBody] LoginDto login)
    {
        throw new NotImplementedException();
    }
}
