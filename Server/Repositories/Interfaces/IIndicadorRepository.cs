using ExtensaoCurricular.Shared.Dtos.General;
using ExtensaoCurricular.Shared.Models.General;

namespace ExtensaoCurricular.Server.Repositories.Interfaces;

public interface IIndicadorRepository : IBaseRepository<Indicador>
{
    Task<List<IndicadorDto>> GetDtosAsync();
}