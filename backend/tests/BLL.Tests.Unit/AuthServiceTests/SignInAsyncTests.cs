using FakeItEasy;
using System.Net;
using UserTestingApp.BLL.Exceptions;
using UserTestingApp.BLL.Services;
using UserTestingApp.BLL.Specifications;
using UserTestingApp.Common.DTOs.Auth;
using UserTestingApp.Common.Security;
using UserTestingApp.DAL.Entities;
using UserTestingApp.DAL.Interfaces;
using Xunit;

using Task = System.Threading.Tasks.Task;

namespace BLL.Tests.Unit.AuthServiceTests;

public class SignInAsyncTests
{
    [Fact]
    public async Task SignInAsync_WhenUserNotExists_ShouldThrow()
    {
        // Arrange
        var userLogin = CreateLoginDto();

        var userRepositoryStub = GetUserRepositoryStub(false);
        var tokenServiceDummy = A.Dummy<TokenService>();

        var authService = new AuthService(userRepositoryStub, tokenServiceDummy);

        // Act
        var act = () => authService.SignInAsync(userLogin);

        // Assert
        var ex = await Assert.ThrowsAsync<ResponseException>(act);
        Assert.Equal(HttpStatusCode.BadRequest, ex.StatusCode);
    }

    [Fact]
    public async Task SignInAsync_WhenInvalidPassword_ShouldThrow()
    {
        // Arrange
        var userLogin = CreateLoginDto();

        var userRepositoryStub = GetUserRepositoryStub(true);
        var tokenServiceDummy = A.Dummy<TokenService>();

        var authService = new AuthService(userRepositoryStub, tokenServiceDummy);

        // Act
        var act = () => authService.SignInAsync(userLogin);

        // Assert
        var ex = await Assert.ThrowsAsync<ResponseException>(act);
        Assert.Equal(HttpStatusCode.BadRequest, ex.StatusCode);
    }

    private static IGenericRepository<User> GetUserRepositoryStub(bool userExists)
    {

        var user = userExists ? CreateUser() : null;
        var userRepositoryStub = A.Fake<IGenericRepository<User>>();

        A.CallTo(() => userRepositoryStub.FirstOrDefaultAsync(A<UserByUsernameSpec>._, A<CancellationToken>._))
            .Returns(user);

        return userRepositoryStub;
    }

    private static User CreateUser()
    {
        var password = "my_password@1";

        var salt = PasswordHasherHelper.GenerateSalt();
        var passwordHash = PasswordHasherHelper.HashPassword(password, salt);

        return new User
        {
            Id = 1,
            PasswordHash = passwordHash,
            Salt = Convert.ToBase64String(salt)
        };
    }
    private static LoginDto CreateLoginDto()
    {
        return new LoginDto("username", "password");
    }
}
