using ExtensaoCurricular.Shared.Models.Geral;

namespace ExtensaoCurricular.Shared.Models.General;

public class Entrada
{
    public int Id { get; set; }
    public DateTime DataEntrada { get; set; }
    public List<Tag> ListTag { get; set; }
    public string Descricao { get; set; }

    public Paciente Paciente { get; set; }
    public int PacienteId { get; set; }
}