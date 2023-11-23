using Blazored.LocalStorage;
using ExtensaoCurricular.Client.Constants;
using Microsoft.AspNetCore.Components;

namespace ExtensaoCurricular.Client.Utils;

public class AuthenticationUtils
{
    //private readonly IAuthService _authService;
    private readonly ILocalStorageService _localStorageService;
    private readonly SnackbarUtils _snackbarUtils;
    private readonly NavigationManager _navigationManager;

    public AuthenticationUtils(/*IAuthService userService,*/ ILocalStorageService localStorageService, SnackbarUtils snackbarUtils, NavigationManager navigationManager)
    {
        //_authService = userService;
        _localStorageService = localStorageService;
        _snackbarUtils = snackbarUtils;
        _navigationManager = navigationManager;
    }

    //public async Task<bool> LoginAsync(LoginForm loginForm)
    //{
    //    var userInfo = await _authService.LoginAsync(loginForm);
    //    if (userInfo is null) return false;

    //    _snackbarUtils.ShowSuccess("Autenticado com sucesso!");
    //    await SetUserInfo(userInfo);
    //    NavigateToIndexPage();
    //    return true;
    //}

    //public async Task<bool> RegisterAsync(RegisterForm registerForm)
    //{
    //    var userInfo = await _authService.RegisterAsync(registerForm);
    //    if (userInfo is null) return false;

    //    _snackbarUtils.ShowSuccess("Registrado com sucesso!");
    //    await SetUserInfo(userInfo);
    //    NavigateToIndexPage();
    //    return true;
    //}

    //public async Task<bool> RequestPasswordResetAsync(string email)
    //{
    //    var hasBeenRequested = await _authService.RequestPasswordResetAsync(email);
    //    return hasBeenRequested;
    //}

    //public async Task<bool> ResetPasswordAsync(PasswordResetInfo passwordResetInfo)
    //{
    //    var hasBeenReseted = await _authService.ResetPasswordAsync(passwordResetInfo);
    //    return hasBeenReseted;
    //}

    //public async Task LogoutAsync()
    //{
    //    if (GlobalValues.UserInfo is null) return;

    //    _snackbarUtils.ShowSuccess("Desconectado com sucesso!");
    //    await SetUserInfo(null);
    //    NavigateToLoginPage();
    //}

    //public async Task VerifyAuthenticationAsync()
    //{
    //    if (GlobalValues.UserInfo is not null) return;

    //    var token = await _localStorageService.GetItemAsync<string>(LocalStorageConstants.TOKEN_KEY);
    //    if (token is null || !await VerifyTokenAndSetUserInfoAsync(token))
    //    {
    //        NavigateToLoginPage();
    //    }
    //}

    //private async Task<bool> VerifyTokenAndSetUserInfoAsync(string token)
    //{
    //    var userInfo = await _authService.ValidateTokenAsync(token);
    //    GlobalValues.UserInfo = userInfo;

    //    return userInfo is not null;
    //}

    //private async Task SetUserInfo(UserInfo userInfo)
    //{
    //    GlobalValues.UserInfo = userInfo;
    //    await SetTokenAsync(userInfo?.Token);
    //}

    //private async Task SetTokenAsync(string token)
    //{
    //    await _localStorageService.SetItemAsync(LocalStorageConstants.TOKEN_KEY, token);
    //}

    private void NavigateToIndexPage() => _navigationManager.NavigateTo(UrlConstants.INDEX);
    private void NavigateToLoginPage() => _navigationManager.NavigateTo(UrlConstants.LOGIN);
}