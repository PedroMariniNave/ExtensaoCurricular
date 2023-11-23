using ExtensaoCurricular.Client.Utils;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace ExtensaoCurricular.Client.Authentication;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly AuthenticationUtils _authenticationUtils;

    public CustomAuthenticationStateProvider(AuthenticationUtils authenticationUtils)
    {
        _authenticationUtils = authenticationUtils;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        //await _authenticationUtils.VerifyAuthenticationAsync();

        List<Claim> claims = null;

        //if (GlobalValues.UserInfo?.Roles is not null)
        //{
        //    claims = (from role in GlobalValues.UserInfo.Roles.GetFlaggedValues()
        //              select new Claim(ClaimTypes.Role, role.ToString())).ToList();
        //}

        claims ??= new List<Claim>();

        var identity = new ClaimsIdentity(claims, "custom");
        var user = new ClaimsPrincipal(identity);

        return await Task.FromResult(new AuthenticationState(user));
    }
}