namespace UserTestingApp.BLL.Interfaces;

public interface ITokenService
{
    public string GenerateAccessToken(long userId);
}
