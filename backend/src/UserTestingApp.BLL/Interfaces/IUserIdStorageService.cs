namespace UserTestingApp.BLL.Interfaces;

public interface IUserIdStorageService : IUserIdGetter
{
    public void SetCurrentUserId(long id);
}
