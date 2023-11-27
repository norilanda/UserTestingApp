using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using System.Net;
using UserTestingApp.BLL.Exceptions;

namespace UserTestingApp.WebAPI.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ResponseException ex)
        {
            await HandleErrorResponse(context, ex.StatusCode, ex.Message);
        }
        catch (Exception ex)
        {
            await HandleErrorResponse(context, HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    private static Task HandleErrorResponse(HttpContext context, HttpStatusCode code, string errorMessage)
    {
        IActionResult result = new JsonResult(errorMessage)
        {
            ContentType = "application/json",
            StatusCode = (int)code
        };

        var actionContext = new ActionContext(context, context.GetRouteData(), new ActionDescriptor());
        return result.ExecuteResultAsync(actionContext);
    }
}
