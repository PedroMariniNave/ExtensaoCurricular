using ExtensaoCurricular.Shared.Models.General;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ExtensaoCurricular.Server.Context.Configurations;

public class MetaTypeConfiguration : IEntityTypeConfiguration<Meta>
{
    public void Configure(EntityTypeBuilder<Meta> builder)
    {
        builder.HasKey(k => k.Id);

        builder.HasOne<Indicador>()
            .WithOne()
            .HasForeignKey<Meta>(f => f.IndicadorId);

        builder.Property(p => p.Porcentagem).HasPrecision(5, 2);
    }
}