using ExtensaoCurricular.Shared.FluentValidation;
using FluentValidation;

namespace ExtensaoCurricular.Shared.Models.General;

public class Indicador
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
}

public class IndicadorValidator : BaseValidator<Indicador>
{
    public IndicadorValidator()
    {
        RuleFor(r => r.Nome)
            .NotEmpty()
            .WithMessage("Necessário informar o nome!");
    }
}