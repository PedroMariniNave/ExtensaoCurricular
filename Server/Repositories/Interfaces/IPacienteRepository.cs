using ExtensaoCurricular.Shared.Dtos.Geral;
using ExtensaoCurricular.Shared.Models.Geral;

namespace ExtensaoCurricular.Server.Repositories.Interfaces;

public interface IPacienteRepository : IBaseRepository<Paciente>
{
    Task<List<PacienteDto>> GetDtosAsync();
}