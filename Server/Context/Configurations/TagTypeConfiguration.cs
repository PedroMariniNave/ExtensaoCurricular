using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ExtensaoCurricular.Shared.Models.General;
using ExtensaoCurricular.Server.Constants;

namespace ExtensaoCurricular.Server.Context.Configurations;

public class TagTypeConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.HasKey(k => k.Id);
        builder.Property(e => e.Tipo)
            .HasConversion<TipoTagConverter>();
    }
}

public class TipoTagConverter : ValueConverter<TipoTag, string>
{
    static readonly Dictionary<String, TipoTag> keyValuePairs = new() {
                { TipoTagConstants.Consulta,TipoTag.Consulta },
                { TipoTagConstants.Exame,TipoTag.Exame },
                { TipoTagConstants.Vacina,TipoTag.Vacina },
                { TipoTagConstants.Cronica,TipoTag.Cronica }


            };

    public TipoTagConverter() : base(v => keyValuePairs.Where(x => x.Value == v).First().Key,
                                     v => keyValuePairs[v])
    {
    }
}