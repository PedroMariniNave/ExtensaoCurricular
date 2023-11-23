using ExtensaoCurricular.Server.Repositories;
using ExtensaoCurricular.Server.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication;

namespace ExtensaoCurricular.Server.Extensions;

public static class ServicesLoaderExtensions
{
    public static void LoadServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IIndicadorRepository, IndicadorRepository>();
        builder.Services.AddScoped<IMetaRepository, MetaRepository>();
        builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();

        builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
    }
}