using ExtensaoCurricular.Client.Services.Interfaces;
using ExtensaoCurricular.Shared.Dtos.Geral;
using ExtensaoCurricular.Shared.Models.Geral;

namespace ExtensaoCurricular.Client.Services;

public class PacienteService : BaseService<Paciente>, IPacienteService
{
    public PacienteService(IHttpClientFactory httpClientFactory, IConfiguration configuration) : base(httpClientFactory, configuration)
    {
    }

    public async Task<List<PacienteDto>> GetDtosAsync()
    {
        var content = await GetAsync();
        return Deserialize<List<PacienteDto>>(content);
    }
}