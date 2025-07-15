using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Anderson_Nunez_AP1_P2.Models;

public class EntradasDetalle
{
    [Key]
    public int EntradaDetalleId { get; set; }

    // Clave foránea a Entrada
    public int EntradaId { get; set; }
    public Entradas? Entrada { get; set; }

    // Clave foránea al Producto usado
    public int ProductoId { get; set; }
    public Productos? Producto { get; set; }

    public int Cantidad { get; set; }
}

