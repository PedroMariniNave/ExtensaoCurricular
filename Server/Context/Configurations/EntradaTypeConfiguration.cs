using ExtensaoCurricular.Shared.Models.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExtensaoCurricular.Server.Context.Configurations;

public class EntradaTypeConfiguration : IEntityTypeConfiguration<Entrada>
{
    public void Configure(EntityTypeBuilder<Entrada> builder)
    {
        builder.HasKey(k => k.Id);

        builder.HasOne(x => x.Paciente)
            .WithMany()
            .HasForeignKey(x => x.PacienteId);

        builder.HasMany(x => x.ListTag)
            .WithMany()
            .UsingEntity<EntradaTag>();
    }
}

//Classe intermediária só visivel (e relevante) para o projeto que contém o context
public class EntradaTag
{
    public int EntradaId { get; set; }
    public int TagId { get; set; }
}