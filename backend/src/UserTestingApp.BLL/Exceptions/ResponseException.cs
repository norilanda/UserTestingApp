using System.Net;

namespace UserTestingApp.BLL.Exceptions;

public class ResponseException : Exception
{
    public HttpStatusCode StatusCode { get; init; }

    public ResponseException(HttpStatusCode statusCode, string message) : base(message)
    {
        StatusCode = statusCode;
    }

    public static ResponseException NotFound(string message = "Entity was not found")
    {
        return new ResponseException(HttpStatusCode.NotFound, message);
    }

    public static ResponseException Forbidden(string message = "Not allowed to perform action")
    {
        return new ResponseException(HttpStatusCode.Forbidden, message);
    }

    public static ResponseException BadRequest(string message = "Invalid parameters")
    {
        return new ResponseException(HttpStatusCode.BadRequest, message);
    }
}
