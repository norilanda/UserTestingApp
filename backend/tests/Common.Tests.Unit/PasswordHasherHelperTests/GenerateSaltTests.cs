using UserTestingApp.Common.Security;
using Xunit;

namespace Common.Tests.Unit.PasswordHasherHelperTests;

public class GenerateSaltTests
{
    [Fact]
    public void GenerateSalt_WhenCalledTwice_ShouldGenerateDifferentSalt()
    {
        // Arrange

        // Act
        var salt1 = PasswordHasherHelper.GenerateSalt();
        var salt2 = PasswordHasherHelper.GenerateSalt();

        // Assert
        int i = 0;
        bool equal = salt1.Length == salt2.Length;

        while (equal && i < salt1.Length && i < salt2.Length)
        {
            if (salt1[i] != salt2[i])
                equal = false;
            i++;
        }

        Assert.False(equal);
    }
}
