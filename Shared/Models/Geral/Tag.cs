namespace ExtensaoCurricular.Shared.Models.General;

public class Tag
{
    public int Id { get; set; }
    public string Codigo { get; set; }
    public string Descricao { get; set; }
    public TipoTag Tipo { get; set; }

}

public enum TipoTag
{
    Consulta,   //cs
    Exame,      //ex
    Vacina,     //vc
    Cronica,     //cr
}