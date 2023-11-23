using ExtensaoCurricular.Server.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ExtensaoCurricular.Server.Filters;

public class GlobalExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        context.ExceptionHandled = true;
        if (context.Exception is HandledException handledException)
        {
            context.Result = new ObjectResult(handledException.Message)
            {
                StatusCode = (int)handledException.HttpStatusCode
            };
            return;
        }

        context.Result = new ObjectResult("Ocorreu um erro no servidor.")
        {
            StatusCode = (int)HttpStatusCode.InternalServerError
        };
    }
}