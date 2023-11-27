using UserTestingApp.BLL.Exceptions;
using UserTestingApp.BLL.Interfaces;

namespace UserTestingApp.BLL.Services;

public class UserIdStorageService : IUserIdStorageService
{
    private long? _id;
    public long GetCurrentUserId() => _id ?? throw ResponseException.Forbidden();

    public void SetCurrentUserId(long userId)
    {
        _id = userId;
    }
}
