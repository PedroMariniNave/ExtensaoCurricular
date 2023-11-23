using ExtensaoCurricular.Shared.Enums;

namespace ExtensaoCurricular.Client.CadModalBase;

public class CadModalBaseInfo
{
    public int Id { get; set; }
    public ETipoCad Tipo { get; set; }
    public bool Visibility { get; set; }

    public void AddCad()
    {
        Tipo = ETipoCad.Add;
        Visibility = true;
    }

    public void EditCad(int id)
    {
        Id = id;
        Tipo = ETipoCad.Edit;
        Visibility = true;
    }

    public void ResetInfo()
    {
        Id = 0;
        Tipo = 0;
        Visibility = false;
    }
}