using ExtensaoCurricular.Shared.Enums;
using ExtensaoCurricular.Shared.FluentValidation;
using ExtensaoCurricular.Shared.Models.General;
using FluentValidation;

namespace ExtensaoCurricular.Shared.Models.Geral;

public class Paciente
{
    public int Id { get; set; }
    public string CPF { get; set; }
    public string NomeCompleto { get; set; }
    public string Telefone { get; set; }
    public DateTime DataNascimento { get; set; }
    public ESexo Sexo { get; set; }
    public List<Tag> ListTag { get; set; }
}

public class PacienteValidator : BaseValidator<Paciente>
{
    public PacienteValidator()
    {
        RuleFor(r => r.NomeCompleto)
            .NotEmpty()
            .WithMessage("Necessário informar o nome!");

        RuleFor(r => r.CPF)
            .Length(11)
            .WithMessage("Necessário informar o CPF!");
    }
}