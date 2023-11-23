using ExtensaoCurricular.Server.Context;
using ExtensaoCurricular.Server.Repositories.Interfaces;
using ExtensaoCurricular.Shared.Dtos.General;
using ExtensaoCurricular.Shared.Models.General;
using Microsoft.EntityFrameworkCore;

namespace ExtensaoCurricular.Server.Repositories;

public class MetaRepository : BaseRepository<Meta>, IMetaRepository
{
    public MetaRepository(ApiDbContext db) : base(db)
    {
    }

    public async Task<List<MetaDto>> GetDtosAsync()
    {
        var list = await (from meta in _db.Metas
                          join indicador in _db.Indicadores on meta.IndicadorId equals indicador.Id
                          select new MetaDto()
                          {
                              Id = meta.Id,
                              NomeDescricaoIndicador = $"{indicador.Nome} - {indicador.Descricao}",
                              Porcentagem = meta.Porcentagem,
                              Ano = meta.Ano
                          }).ToListAsync();
        return list;
    }
}