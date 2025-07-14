using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Anderson_Nunez_AP1_P2.Models;

public class Producto 
{
    [Key]
    public int ProdutoId { get; set; }

    [Required(ErrorMessage ="Campo Fecha Obligatorio")]
    public DateTime Fecha { get; set; }

    [Required(ErrorMessage ="Campo descripcion obligaotrio")]
    [StringLength(100, ErrorMessage ="Maximo 100 Caracteres")]
    public string? Descripcion { get; set; }

    [Required(ErrorMessage ="Campo Monto Obligatorio")]
    [Range(1, double.MaxValue, ErrorMessage ="El monto debe ser mayor que 0")]
    public decimal Monto { get; set; }

    


}
