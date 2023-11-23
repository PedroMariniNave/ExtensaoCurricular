using ExtensaoCurricular.Shared.Dtos.General;
using ExtensaoCurricular.Shared.Models.General;

namespace ExtensaoCurricular.Client.Services.Interfaces;

public interface IMetaService : IBaseService<Meta>
{
    Task<List<MetaDto>> GetDtosAsync();
}