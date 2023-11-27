using UserTestingApp.BLL.Interfaces;

namespace UserTestingApp.WebAPI.Middlewares;

public class CurrentUserIdMiddleware
{
    private readonly RequestDelegate _next;

    public CurrentUserIdMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, IUserIdStorageService userIdStorage)
    {
        var userClaimId = context.User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
        if (userClaimId != null && long.TryParse(userClaimId, out long userId))
        {
            userIdStorage.SetCurrentUserId(userId);
        }

        await _next.Invoke(context);
    }
}
