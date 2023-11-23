using MudBlazor;

namespace ExtensaoCurricular.Client.Utils;

public class SnackbarUtils
{
    private readonly ISnackbar _snackbarService;

    public SnackbarUtils(ISnackbar snackbarService)
    {
        _snackbarService = snackbarService;
    }

    public void ShowSuccess(string text)
    {
        Show(text, Color.Success, Severity.Success);
    }

    public void ShowInfo(string text)
    {
        Show(text, Color.Info, Severity.Info);
    }

    public void ShowWarning(string text)
    {
        Show(text, Color.Warning, Severity.Warning);
    }

    public void ShowError(string text)
    {
        Show(text, Color.Error, Severity.Error);
    }

    public void Show(string text, Color color = Color.Primary, Severity severity = Severity.Normal)
    {
        _snackbarService.Add(text, severity, (config) =>
        {
            config.ActionColor = color;
        });
    }
}