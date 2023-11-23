using ExtensaoCurricular.Server.Context;
using ExtensaoCurricular.Server.Repositories.Interfaces;
using ExtensaoCurricular.Shared.Dtos.General;
using ExtensaoCurricular.Shared.Models.General;
using Microsoft.EntityFrameworkCore;

namespace ExtensaoCurricular.Server.Repositories;

public class IndicadorRepository : BaseRepository<Indicador>, IIndicadorRepository
{
    public IndicadorRepository(ApiDbContext db) : base(db)
    {
    }

    public async Task<List<IndicadorDto>> GetDtosAsync()
    {
        var list = await (from indicador in _db.Indicadores
                          select new IndicadorDto()
                          {
                              Id = indicador.Id,
                              Nome = indicador.Nome,
                              Descricao = indicador.Descricao
                          }).ToListAsync();
        return list;
    }
}