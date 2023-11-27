using UserTestingApp.BLL.Exceptions;
using UserTestingApp.BLL.Interfaces;
using UserTestingApp.BLL.Specifications;
using UserTestingApp.Common.DTOs.Auth;
using UserTestingApp.Common.Security;
using UserTestingApp.DAL.Entities;
using UserTestingApp.DAL.Interfaces;

namespace UserTestingApp.BLL.Services;

public class AuthService : IAuthService
{
    private readonly IGenericRepository<User> _userRepository;
    private readonly ITokenService _tokenService;

    public AuthService(IGenericRepository<User> userRepository, ITokenService tokenService)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
    }

    public async Task<TokenDto> SignInAsync(LoginDto userDto)
    {
        var userSpec = new UserByUsernameSpec(userDto.Username);
        var user = await _userRepository.FirstOrDefaultAsync(userSpec);

        if (user == null)
            throw ResponseException.BadRequest("Invalid credentials");

        var passwordVerified = PasswordHasherHelper.VerifyPassword(userDto.Password, user.PasswordHash, Convert.FromBase64String(user.Salt));

        if (!passwordVerified)
            throw ResponseException.BadRequest("Invalid credentials");

        var token = _tokenService.GenerateAccessToken(user.Id);
        return new TokenDto(token);
    }
}
