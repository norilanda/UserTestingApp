using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace UserTestingApp.BLL.Options;

public class JwtOptions
{
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public double Lifetime { get; set; }
    public string SecretKey { get; set; } = string.Empty;
    public string SecurityAlgorithm { get; set; } = string.Empty;
    public static SymmetricSecurityKey GetSymmetricSecurityKey(string secretKey)
    {
        return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
    }
}
