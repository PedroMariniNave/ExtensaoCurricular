using ExtensaoCurricular.Client.Services.Interfaces;
using ExtensaoCurricular.Shared.Dtos.General;
using ExtensaoCurricular.Shared.Models.General;

namespace ExtensaoCurricular.Client.Services;

public class IndicadorService : BaseService<Indicador>, IIndicadorService
{
    public IndicadorService(IHttpClientFactory httpClientFactory, IConfiguration configuration) : base(httpClientFactory, configuration)
    {
    }

    public async Task<List<IndicadorDto>> GetDtosAsync()
    {
        var content = await GetAsync();
        return Deserialize<List<IndicadorDto>>(content);
    }
}