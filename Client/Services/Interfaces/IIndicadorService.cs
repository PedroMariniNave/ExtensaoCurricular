using ExtensaoCurricular.Shared.Dtos.General;
using ExtensaoCurricular.Shared.Models.General;

namespace ExtensaoCurricular.Client.Services.Interfaces;

public interface IIndicadorService : IBaseService<Indicador>
{
    Task<List<IndicadorDto>> GetDtosAsync();
}