using ExtensaoCurricular.Server.Extensions;
using ExtensaoCurricular.Shared.Models.General;
using ExtensaoCurricular.Shared.Models.Geral;
using Microsoft.EntityFrameworkCore;

namespace ExtensaoCurricular.Server.Context;

public class ApiDbContext : DbContext
{
    public int UserId { get; set; }

    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Procura por todos as classes que implementam a interface IEntityTypeConfiguration e aplica as configurações
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApiDbContext).Assembly);

        LoadInitialData(modelBuilder);
    }

    private static void LoadInitialData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Indicador>()
                        .HasData(
                            new Indicador()
                            {
                                Id = 1,
                                Nome = "1 - Gestantes",
                                Descricao = "Proporção de gestantes com pelo menos 6 consultas pré-natal realizadas, sendo a 1ª até a 12ª semana de gestação."
                            },
                            new Indicador()
                            {
                                Id = 2,
                                Nome = "2 - Gestantes",
                                Descricao = "Proporção de gestantes com realização de exames para sífilis e HIV."
                            },
                            new Indicador()
                            {
                                Id = 3,
                                Nome = "3 - Gestantes",
                                Descricao = "Proporção de gestantes com atendimento odontológico realizado."
                            },
                            new Indicador()
                            {
                                Id = 4,
                                Nome = "4 - Mulheres",
                                Descricao = "Proporção de mulheres com coleta de citopatológico na APS."
                            },
                            new Indicador()
                            {
                                Id = 5,
                                Nome = "5 - Crianças",
                                Descricao = "Proporção de crianças de 1 ano de idade vacinadas na APS contra Difteria, Tétano, Coqueluche, Hepatite B, infecções causadas por haemophilus influenzae tipo B e Poliomielite inativada."
                            },
                            new Indicador()
                            {
                                Id = 6,
                                Nome = "6 - Geral",
                                Descricao = "Proporção de pessoas com hipertensão, com consulta e pressão arterial aferida no semestre."
                            },
                            new Indicador()
                            {
                                Id = 7,
                                Nome = "7 - Geral",
                                Descricao = "Proporção de pessoas com diabetes, com consulta e hemoglobina glicada solicitada no semestre."
                            });

        modelBuilder.Entity<Meta>()
                        .HasData(
                            new Meta()
                            {
                                Id = 1,
                                IndicadorId = 1,
                                Ano = 2022,
                                Porcentagem = 45
                            },
                            new Meta()
                            {
                                Id = 2,
                                IndicadorId = 2,
                                Ano = 2022,
                                Porcentagem = 60
                            },
                            new Meta()
                            {
                                Id = 3,
                                IndicadorId = 3,
                                Ano = 2022,
                                Porcentagem = 60
                            },
                            new Meta()
                            {
                                Id = 4,
                                IndicadorId = 4,
                                Ano = 2022,
                                Porcentagem = 40
                            },
                            new Meta()
                            {
                                Id = 5,
                                IndicadorId = 5,
                                Ano = 2022,
                                Porcentagem = 95
                            },
                            new Meta()
                            {
                                Id = 6,
                                IndicadorId = 6,
                                Ano = 2022,
                                Porcentagem = 50
                            },
                            new Meta()
                            {
                                Id = 7,
                                IndicadorId = 7,
                                Ano = 2022,
                                Porcentagem = 50
                            });
    }

    public DbSet<Indicador> Indicadores { get; set; }
    public DbSet<Meta> Metas { get; set; }
    public DbSet<Paciente> Pacientes { get; set; }
}