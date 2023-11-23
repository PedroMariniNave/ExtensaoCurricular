using ExtensaoCurricular.Client.Services;
using ExtensaoCurricular.Client.Services.Interfaces;
using ExtensaoCurricular.Client.Utils;

namespace ExtensaoCurricular.Client.Extensions;

public static class ServicesLoaderExtension
{
    public static void LoadServices(this IServiceCollection service)
    {
        service.AddScoped<IIndicadorService, IndicadorService>();
        service.AddScoped<IMetaService, MetaService>();
        service.AddScoped<IPacienteService, PacienteService>();

        service.AddTransient<AuthenticationUtils>();
        service.AddTransient<SnackbarUtils>();
        service.AddTransient<MethodInjectionUtils>();
        service.AddTransient<InterceptorUtils>();
    }
}