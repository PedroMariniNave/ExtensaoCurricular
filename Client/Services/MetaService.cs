using ExtensaoCurricular.Client.Services.Interfaces;
using ExtensaoCurricular.Shared.Dtos.General;
using ExtensaoCurricular.Shared.Models.General;

namespace ExtensaoCurricular.Client.Services;

public class MetaService : BaseService<Meta>, IMetaService
{
    public MetaService(IHttpClientFactory httpClientFactory, IConfiguration configuration) : base(httpClientFactory, configuration)
    {
    }

    public async Task<List<MetaDto>> GetDtosAsync()
    {
        var content = await GetAsync();
        return Deserialize<List<MetaDto>>(content);
    }
}