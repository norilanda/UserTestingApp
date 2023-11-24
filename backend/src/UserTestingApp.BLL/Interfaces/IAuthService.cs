using UserTestingApp.Common.DTOs.Auth;

namespace UserTestingApp.BLL.Interfaces;

public interface IAuthService
{
    public Task<TokenDto> SignInAsync(LoginDto user);
}
