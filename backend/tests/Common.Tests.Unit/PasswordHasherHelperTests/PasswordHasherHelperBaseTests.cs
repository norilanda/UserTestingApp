using System.Security.Cryptography;

namespace Common.Tests.Unit.PasswordHasherHelperTests;

public class PasswordHasherHelperBaseTests
{
    protected static byte[] GenerateSalt()
    {
        int keySize = 64;
        return RandomNumberGenerator.GetBytes(keySize);
    }
}
