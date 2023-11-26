using UserTestingApp.Common.Security;
using Xunit;

namespace Common.Tests.Unit.PasswordHasherHelperTests;

public class HashPasswordTests : PasswordHasherHelperBaseTests
{
    [Fact]
    public void HashPassword_WhenSamePasswordAndDifferentSalt_ShouldGenerateDifferentHash()
    {
        // Arrange
        var password1 = "my_password@1";
        var password2 = password1;

        var salt1 = GenerateSalt();
        var salt2 = GenerateSalt();

        // Act
        var passwordHash1 = PasswordHasherHelper.HashPassword(password1, salt1);
        var passwordHash2 = PasswordHasherHelper.HashPassword(password2, salt2);

        // Assert
        Assert.NotEqual(passwordHash1, passwordHash2);
    }

    [Fact]
    public void HashPassword_WhenSamePasswordAndSameSalt_ShouldGenerateSameHash()
    {
        // Arrange
        var password1 = "my_password@1";
        var password2 = password1;

        var salt1 = GenerateSalt();
        var salt2 = salt1;

        // Act
        var passwordHash1 = PasswordHasherHelper.HashPassword(password1, salt1);
        var passwordHash2 = PasswordHasherHelper.HashPassword(password2, salt2);

        // Assert
        Assert.Equal(passwordHash1, passwordHash2);
    }
}
