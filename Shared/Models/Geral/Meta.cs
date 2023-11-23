using ExtensaoCurricular.Shared.FluentValidation;
using FluentValidation;

namespace ExtensaoCurricular.Shared.Models.General;

public class Meta
{
    public int Id { get; set; }
    public int IndicadorId { get; set; }
    public decimal Porcentagem { get; set; }
    public int Ano { get; set; }
}

public class MetaValidator : BaseValidator<Meta>
{
    public MetaValidator()
    {
        RuleFor(r => r.IndicadorId)
            .GreaterThan(0)
            .WithMessage("Necessário selecionar um indicador!");

        RuleFor(r => r.Porcentagem)
            .GreaterThan(0)
            .WithMessage("A porcentagem deve ser maior que zero!")
            .LessThanOrEqualTo(100)
            .WithMessage("A porcentagem não deve ultrapassar 100%");

        RuleFor(r => r.Ano)
            .GreaterThan(0)
            .WithMessage("Necessário informar o ano!");
    }
}