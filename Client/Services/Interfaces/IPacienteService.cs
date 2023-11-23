using ExtensaoCurricular.Shared.Dtos.Geral;
using ExtensaoCurricular.Shared.Models.Geral;

namespace ExtensaoCurricular.Client.Services.Interfaces;

public interface IPacienteService : IBaseService<Paciente>
{
    Task<List<PacienteDto>> GetDtosAsync();
}