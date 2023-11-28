using System.Security.Cryptography;
using System.Text;

namespace UserTestingApp.Common.Security;

public static class PasswordHasherHelper
{
    private const int _keySize = 64;
    private const int _iterations = 10000;
    private static readonly HashAlgorithmName _hashAlgorithm = HashAlgorithmName.SHA512;

    public static byte[] GenerateSalt()
    {
        return RandomNumberGenerator.GetBytes(_keySize);
    }

    public static string HashPassword(string password, byte[] salt)
    {
        var hash = GenerateHash(password, salt);

        return Convert.ToHexString(hash);
    }

    private static byte[] GenerateHash(string password, byte[] salt)
    {
        return Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(password),
            salt,
            _iterations,
            _hashAlgorithm,
            _keySize);
    }

    public static bool VerifyPassword(string password, string hash, byte[] salt)
    {
        var incomePasswordHash = GenerateHash(password, salt);
        return CryptographicOperations.FixedTimeEquals(incomePasswordHash, Convert.FromHexString(hash));
    }
}
