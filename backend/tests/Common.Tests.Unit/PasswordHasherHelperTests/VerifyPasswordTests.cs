using UserTestingApp.Common.Security;
using Xunit;

namespace Common.Tests.Unit.PasswordHasherHelperTests;

public class VerifyPasswordTests : PasswordHasherHelperBaseTests
{
    [Fact]
    public void VerifyPassword_WhenPasswordMatches_ShouldBeTrue()
    {
        // Arrange
        var password = "my_password@1";
        var salt = GenerateSalt();

        var passwordHash = PasswordHasherHelper.HashPassword(password, salt);

        // Act
        var matches = PasswordHasherHelper.VerifyPassword(password, passwordHash, salt);

        // Assert
        Assert.True(matches);
    }

    [Fact]
    public void VerifyPassword_WhenPasswordNotMatches_ShouldBeFalse()
    {
        // Arrange
        var password = "my_password@1";
        var notMatchingPassword = "other-password";

        var salt = GenerateSalt();

        var passwordHash = PasswordHasherHelper.HashPassword(password, salt);

        // Act
        var matches = PasswordHasherHelper.VerifyPassword(notMatchingPassword, passwordHash, salt);

        // Assert
        Assert.False(matches);
    }
}
