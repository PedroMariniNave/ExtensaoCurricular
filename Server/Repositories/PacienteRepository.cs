using ExtensaoCurricular.Server.Context;
using ExtensaoCurricular.Server.Repositories.Interfaces;
using ExtensaoCurricular.Shared.Dtos.Geral;
using ExtensaoCurricular.Shared.Models.Geral;
using Microsoft.EntityFrameworkCore;

namespace ExtensaoCurricular.Server.Repositories;

public class PacienteRepository : BaseRepository<Paciente>, IPacienteRepository
{
    public PacienteRepository(ApiDbContext db) : base(db)
    {
    }

    public async Task<List<PacienteDto>> GetDtosAsync()
    {
        var list = await (from paciente in _db.Pacientes
                          select new PacienteDto()
                          {
                              Id = paciente.Id,
                              Nome = paciente.NomeCompleto,
                              Telefone = paciente.Telefone,
                              DataNascimento = paciente.DataNascimento
                          }).ToListAsync();
        return list;
    }
}