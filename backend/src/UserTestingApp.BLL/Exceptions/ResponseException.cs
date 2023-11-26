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
}
