using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ExtensaoCurricular.Shared.Models.Geral;
using ExtensaoCurricular.Shared.Enums;

namespace ExtensaoCurricular.Server.Context.Configurations;

public class PacienteTypeConfiguration : IEntityTypeConfiguration<Paciente>
{
    public void Configure(EntityTypeBuilder<Paciente> builder)
    {
        builder.HasKey(k => k.Id);

        builder.Property(e => e.Sexo)
                .HasConversion<SexoConverter>();

        builder.HasMany(x => x.ListTag)
            .WithMany()
            .UsingEntity<PacienteTag>();
    }

    public class SexoConverter : ValueConverter<ESexo, char>
    {
        static readonly Dictionary<char, ESexo> keyValuePairs = new() {
                { nameof(ESexo.Masculino).First(), ESexo.Masculino },
                { nameof(ESexo.Feminino).First(), ESexo.Feminino },
            };

        public SexoConverter()
            : base(
                v => keyValuePairs.Where(x => x.Value == v).First().Key,
                v => keyValuePairs[v])
        {
        }
    }
}

//Classe intermediaria só visivel(e relevante) para o projeto que contem o context
public class PacienteTag
{
    public int PacienteId { get; set; }
    public int TagId { get; set; }
}