using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ExtensaoCurricular.Shared.Enums;

public enum ETipoCad : sbyte
{
    [Description("Novo")]
    [Display(Name = "Adicionar")]
    Add = 1,

    [Description("Editar")]
    [Display(Name = "Editar")]
    Edit = 2
}