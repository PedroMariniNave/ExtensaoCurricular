using System.Net;
using Toolbelt.Blazor;

namespace ExtensaoCurricular.Client.Utils;

public class InterceptorUtils
{
    private readonly MethodInjectionUtils _methodInjectionUtils;
    private readonly SnackbarUtils _snackbarUtils;
    private readonly Dictionary<HttpStatusCode, string> HttpStatusMethods = new();
    //{
    //    { HttpStatusCode.Unauthorized, GeneralConstants.LOGIN_METHOD },
    //    { HttpStatusCode.TooManyRequests, GeneralConstants.SHOW_TOO_MANY_REQUESTS_MESSAGE }
    //};

    public InterceptorUtils(MethodInjectionUtils methodInjectionUtils, SnackbarUtils snackbarUtils)
    {
        _methodInjectionUtils = methodInjectionUtils;
        _snackbarUtils = snackbarUtils;
    }

    public async Task HandleHttpStatusCodeAsync(object sender, HttpClientInterceptorEventArgs args)
    {
        if (args.Response is null) return;

        await HandleErrorMessageInResponse(args.Response);

        var statusCode = args.Response.StatusCode;
        if (!HttpStatusMethods.ContainsKey(statusCode)) return;

        var methodName = HttpStatusMethods[statusCode];
        if (!_methodInjectionUtils.Methods.ContainsKey(methodName)) return;

        _methodInjectionUtils.Invoke(methodName);
    }

    private async Task HandleErrorMessageInResponse(HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode) return;

        var message = await response.Content.ReadAsStringAsync();
        _snackbarUtils.ShowError(message);
    }
}