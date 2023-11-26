using UserTestingApp.BLL.Interfaces;
using UserTestingApp.Common.DTOs.Auth;

namespace UserTestingApp.BLL.Services;

public class AuthService : IAuthService
{
    public Task<TokenDto> SignInAsync(LoginDto user)
    {
        throw new NotImplementedException();
    }
}
