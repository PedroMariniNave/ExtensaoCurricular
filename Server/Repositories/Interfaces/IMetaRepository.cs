using ExtensaoCurricular.Shared.Dtos.General;
using ExtensaoCurricular.Shared.Models.General;

namespace ExtensaoCurricular.Server.Repositories.Interfaces;

public interface IMetaRepository : IBaseRepository<Meta>
{
    Task<List<MetaDto>> GetDtosAsync();
}