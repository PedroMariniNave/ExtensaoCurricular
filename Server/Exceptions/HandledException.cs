using System.Net;

namespace ExtensaoCurricular.Server.Exceptions;

public class HandledException : Exception
{
    public HttpStatusCode HttpStatusCode { get; init; }

    public HandledException(string message, HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest) : base(message)
    {
        HttpStatusCode = httpStatusCode;
    }
}