using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Anderson_Nunez_AP1_P2.Models;

public class Parcial
{
    [Key]
    public int ParcialId { get; set; }

    [Required(ErrorMessage ="Campo Fecha Obligatorio")]
    public DateTime Fecha { get; set; }

    [Required(ErrorMessage ="Campo Nombre Obligatorio")]
    [StringLength(100, ErrorMessage ="Maximo 100 Caracteres")]
    public string? Nombre { get; set; }

    [Required(ErrorMessage ="Campo Monto Obligatorio")]
    [Range(1, double.MaxValue, ErrorMessage ="El monto debe ser mayor que 0")]
    public decimal Monto { get; set; }

    


}
